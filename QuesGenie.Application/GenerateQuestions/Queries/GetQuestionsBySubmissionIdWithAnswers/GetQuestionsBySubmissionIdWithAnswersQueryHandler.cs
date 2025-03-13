using AutoMapper;
using MediatR;
using QuesGenie.Application.GenerateQuestions.QuestionsDtoWithAnswer;
using QuesGenie.Domain.Exceptions;
using QuesGenie.Domain.Repositories;

namespace QuesGenie.Application.GenerateQuestions.Queries.GetQuestionsBySubmissionIdWithAnswers;

public class GetQuestionsBySubmissionIdWithAnswersQueryHandler(IUnitOfWork unitOfWork,
    IMapper mapper):IRequestHandler<GetQuestionsBySubmissionIdWithAnswersQuery
    , GetQuestionsBySubmissionIdWithAnswerDto>
{
    public async Task<GetQuestionsBySubmissionIdWithAnswerDto> Handle(GetQuestionsBySubmissionIdWithAnswersQuery request, CancellationToken cancellationToken)
    {
        var submission = await unitOfWork.Submission.GetOrDefalutAsync(x => x.SubmissionId ==
                                                                            request.submissionId,
            IncludeProperties:"QuestionSets");
        if(submission is null)
            throw new NotFoundException(nameof(submission), request.submissionId);

        var submissionDto = new GetQuestionsBySubmissionIdWithAnswerDto();
        submissionDto.SubmissionId = submission.SubmissionId;
        submissionDto.UserId = submission.UserId;
        submission.SubmissionDate = submission.SubmissionDate;
        submissionDto.SampleQuestions = submission.SampleQuestions;
        
        foreach (var questionSet in submission.QuestionSets)
        {
            var (mcqQuestions, matchingQuestions, fillTheBlankQuestions, trueFalseQuestions, status) = 
                await unitOfWork.QuestionSet.GetQuestionsByQuestionSetId(questionSet.QuestionSetId, cancellationToken);

            var questionSetDto = new GetQuestionSetAnswerDto()
            {
                QuestionSetId = questionSet.QuestionSetId,
                Status = status,
                McqQuestions = mapper.Map<List<McqQuestionsAnswerDto>>(mcqQuestions),
                MatchingQuestions = mapper.Map<List<MatchingQuestionsAnswerDto>>(matchingQuestions),
                TrueFalseQuestions = mapper.Map<List<TrueFalseAnswerDto>>(trueFalseQuestions),
                FillTheBlanks = mapper.Map<List<FillTheBlankAnswerDto>>(fillTheBlankQuestions)
            };
            
            submissionDto.QuestionSets.Add(questionSetDto);
        }
        return submissionDto;
    }
}