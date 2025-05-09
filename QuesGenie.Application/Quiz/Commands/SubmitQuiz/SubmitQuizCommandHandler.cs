using System.Text.RegularExpressions;
using AutoMapper;
using MediatR;
using QuesGenie.Application.Quiz.Dtos;
using QuesGenie.Domain.Entities;
using QuesGenie.Domain.Enums;
using QuesGenie.Domain.Exceptions;
using QuesGenie.Domain.Repositories;

namespace QuesGenie.Application.Quiz.Commands.SubmitQuiz;

public class SubmitQuizCommandHandler(IUnitOfWork unitOfWork,IMapper mapper)
    :IRequestHandler<SubmitQuizCommand,SubmitQuizResponseDto>
{
    public async Task<SubmitQuizResponseDto> Handle(SubmitQuizCommand request, CancellationToken cancellationToken)
    {
        // Get quiz and check if it is valid (not finished or it's existence)
        
        var quiz = await unitOfWork.Quizzes
            .GetOrDefalutAsync(x => x.QuizId == request.QuizId);
        
        if(quiz is null)
            throw new NotFoundException(nameof(Quiz), request.QuizId);
        
        if(quiz.Status == QuizStatus.FINISHED)
            throw new CustomException("The quiz has already been submitted");
        
        // Get questionSetId and the correct answers 
        
        var (mcqQuestions,
            matchingQuestions,
            fillTheBlankQuestions,
            trueFalseQuestions
            , status) = await unitOfWork.QuestionSet.GetQuestionsByQuestionSetId(quiz.QuestionSetId,
            cancellationToken);
        
        // Get the estimated score number
        double TotalScore = mcqQuestions.Count() + matchingQuestions.Select(x => x.MatchingPairs.Count()).Sum() + fillTheBlankQuestions.Count()
            + trueFalseQuestions.Count();
        
        // compare user answers with the correct one
        double userScore = 0;
        List<QuizResponses> responses = new List<QuizResponses>();


        // mcq
        ProcessMcqAnswers(request.McqQuizAnswers, quiz, mcqQuestions, ref userScore, responses);
        
        // fillInTheBlank
        ProcessFillInTheBlankAnswers(request.FillTheBlnakAnswers, quiz, fillTheBlankQuestions, ref userScore,
            responses);
        
        // TrueFalse
        ProcessTrueFalseAnswers(request.TrueFalseQuizAnswers, quiz, trueFalseQuestions, ref userScore, responses);
        
        // Matching
        ProcessMatchingAnswers(request.MatchingQuizAnswers, quiz, matchingQuestions, ref userScore, responses);
      
        
        // update score of the quiz and save user answer 
        var finalScore = Math.Round((userScore / TotalScore) * 100, 2);
        quiz.Status = QuizStatus.FINISHED;
        quiz.Responses = responses;
        quiz.Score = finalScore;
        unitOfWork.Quizzes.Update(quiz);
        await unitOfWork.SaveAsync();

        var response = new SubmitQuizResponseDto();
        response.Score = finalScore;
        response.QuizId = quiz.QuizId;
        response.QuizResponses = responses.Select(r =>
        {
            var dto = mapper.Map<QuizResponseDto>(r);
            if (r.Question is McqQuestions mcqQuestion)
            {
                dto.McqQuestion = mapper.Map<SubmitMcqQuestionQuizDto>(mcqQuestion);
            }else if (r.Question is TrueFalseQuestions trueFalseQuestion)
            {
                dto.TrueFalseQuestion = mapper.Map<SubmitTrueFalseQuestionDto>(trueFalseQuestion);
            }else if (r.Question is FillTheBlankQuestions fillTheBlankQuestion)
            {
                dto.FillTheBlankQuiz = mapper.Map<SubmitFillTheBlankQuizDto>(fillTheBlankQuestion);
            }else if (r.Question is MatchingQuestions matchingQuestion)
            {
                dto.MatchingQuestion = mapper.Map<SubmitMatchingQuestionDto>(matchingQuestion);
            }
            return dto;
        }).ToList();

        return response;
    }

    private void ProcessMcqAnswers(List<McqQuizAnswerDto> McqQuizAnswers, Quizzes quiz,
        List<McqQuestions> mcqQuestions,ref double userScore,List<QuizResponses> responses)
    {
        foreach (var userAnswer in McqQuizAnswers)
        {
            var questionId = userAnswer.QuestionId;
            var optionId = userAnswer.OptionId;
            
            
            var question= mcqQuestions.FirstOrDefault(x => x.QuestionId
                                                           == questionId);
            if(question is null)
                throw new NotFoundException(nameof(question), questionId);
            
           
            
            var option =  question.McqOptions.FirstOrDefault(x => x.OptionId == optionId);
            if(option is null)
                throw new NotFoundException(nameof(option), optionId);

            var quizResponse = new QuizResponses
            {
                QuizId = quiz.QuizId,
                QuestionId = question.QuestionId,
                Question = question,  
                UserAnswer = option.OptionText,
                IsCorrectAnswer = option.IsCorrectAnswer
            };

            if (option.IsCorrectAnswer)
            {
                userScore += 1;
                quizResponse.IsCorrectAnswer = true;
            }
            else
            {
                quizResponse.IsCorrectAnswer = false;
            }
            responses.Add(quizResponse);    
        }
    }
    
    private void ProcessFillInTheBlankAnswers(List<FillTheBlankQuizAnswerDto> fillTheBlankQuiz, Quizzes quiz,
        List<FillTheBlankQuestions> fillTheBlankQuestions, ref double userScore, List<QuizResponses> responses)
    {
        foreach (var userAnswer in fillTheBlankQuiz)
        {
            var questionId = userAnswer.QuestionId;
            var answer = userAnswer.Answer;
            
            
            var question= fillTheBlankQuestions.FirstOrDefault(x => x.QuestionId == questionId);
            if(question is null)
                throw new NotFoundException(nameof(question), questionId);
            
            
            var quizResponse = new QuizResponses
            {
                QuizId = quiz.QuizId,
                QuestionId = question.QuestionId,
                Question = question, 
                UserAnswer = answer,
            };

            if (string.Equals(question.AnswerText.ToLower(), answer.ToLower(), StringComparison.OrdinalIgnoreCase))
            {
                quizResponse.IsCorrectAnswer = true;
                userScore += 1;
            }
            else
            {
                quizResponse.IsCorrectAnswer = false;
            }
            responses.Add(quizResponse);
        }
    }

    private void ProcessTrueFalseAnswers(List<TrueFalseQuizAnswerDto> TrueFalseQuizAnswers, Quizzes quiz,
        List<TrueFalseQuestions> trueFalseQuestions, ref double userScore, List<QuizResponses> responses)
    {
        foreach (var userAnswer in TrueFalseQuizAnswers)
        {
            var questionId = userAnswer.QuestionId;
            var isCorrect = userAnswer.TrueFalse;
            
            
            var question= trueFalseQuestions.FirstOrDefault(x => x.QuestionId == questionId);
            if(question is null)
                throw new NotFoundException(nameof(question), questionId);
            
           
            
            
            var quizResponse = new QuizResponses
            {
                QuizId = quiz.QuizId,
                QuestionId = question.QuestionId,
                Question = question,  
                UserAnswer = isCorrect.ToString(),
            };
            
            if (question.Answer == isCorrect)
            {
                quizResponse.IsCorrectAnswer = true;
                userScore += 1;
            }
            else
            {
                quizResponse.IsCorrectAnswer = false;
            }
            responses.Add(quizResponse);
        }
    }

    private void ProcessMatchingAnswers(List<MatchingQuizAnswerDto> MatchingQuizAnswers, Quizzes quiz,
        List<MatchingQuestions> matchingQuestions, ref double userScore, List<QuizResponses> responses)
    {
        foreach (var userAnswer in MatchingQuizAnswers)
        {
            var questionId = userAnswer.QuestionId;
           
            
            var question= matchingQuestions.FirstOrDefault(x => x.QuestionId == questionId);
            if(question is null)
                throw new NotFoundException(nameof(question), questionId);
            
            
            var totalAnswerPairs = userAnswer.MatchingPairsQuiz.Count();
            int correctAnswers = 0;
            
            var matchingPairsDict = question.MatchingPairs.ToDictionary( p => p.LeftSide,
                p => p.RightSide);
            
            foreach (var answerPair in userAnswer.MatchingPairsQuiz)
            {
                if (matchingPairsDict.TryGetValue(answerPair.LeftSide, out var correctRightSide) &&
                    answerPair.RightSide == correctRightSide)
                {
                    userScore += 1;
                    correctAnswers += 1;
                }
            }
            var quizResponse = new QuizResponses
            {
                QuizId = quiz.QuizId,
                QuestionId = question.QuestionId,
                Question = question,  
                UserAnswer = "Matching question",
                IsCorrectAnswer = correctAnswers == totalAnswerPairs
            };
            responses.Add(quizResponse);
        }
    }
}