using AutoMapper;
using MediatR;
using QuesGenie.Application.GenerateQuestions.Dtos;
using QuesGenie.Application.Quiz.Dtos;
using QuesGenie.Application.Services.User;
using QuesGenie.Domain.Entities;
using QuesGenie.Domain.Enums;
using QuesGenie.Domain.Exceptions;
using QuesGenie.Domain.Repositories;

namespace QuesGenie.Application.Quiz.Commands.StartQuiz;

public class StartQuizCommandHandler(IUnitOfWork unitOfWork,
    IMapper mapper,IUserContext userContext):IRequestHandler<StartQuizCommand,QuizDto>
{
    public async Task<QuizDto> Handle(StartQuizCommand request, CancellationToken cancellationToken)
    {
        var userId = userContext.GetCurrentUser().userId;
        var submission = await unitOfWork.Submission
            .GetOrDefalutAsync(x => x.SubmissionId==request.submissionId,
                IncludeProperties:"QuestionSets");
        
        if(submission is null)
            throw new NotFoundException(nameof(submission), request.submissionId);
        
        Random rng = new Random();
        var questionSetId = submission.QuestionSets
            .Select(x => x.QuestionSetId).OrderBy(_ => rng.Next()).First();
        
        var quizId = Guid.NewGuid().ToString();
        
        var quiz = new Quizzes
        {
            QuizId = quizId,
            UserId = userId,
            QuestionSetId = questionSetId,
            Status = QuizStatus.RUNNING,
        };
        
        await unitOfWork.Quizzes.AddAsync(quiz);
        await unitOfWork.SaveAsync();
        
        var (mcqQuestions,
            matchingQuestions,
            fillTheBlankQuestions,
            trueFalseQuestions
            , status) = await unitOfWork.QuestionSet.GetQuestionsByQuestionSetId(questionSetId,
            cancellationToken);
        
        var quizDto = new QuizDto();
        
        quizDto.QuizId = quizId;
        quizDto.MatchingQuestions = mapper.Map<List<MatchingQuestionsDto>>(matchingQuestions);
        quizDto.McqQuestions = mapper.Map<List<McqQuestionsDto>>(mcqQuestions);
        quizDto.TrueFalseQuestions = mapper.Map<List<TrueFalseQuestionsDto>>(trueFalseQuestions);
        quizDto.FillTheBlanks = mapper.Map<List<FillTheBlankDto>>(fillTheBlankQuestions);
        
        return quizDto;
    }
}