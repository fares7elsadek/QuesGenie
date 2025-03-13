using AutoMapper;
using MediatR;
using QuesGenie.Application.GenerateQuestions.Dtos;
using QuesGenie.Domain.Exceptions;
using QuesGenie.Domain.Repositories;

namespace QuesGenie.Application.GenerateQuestions.Queries.GetQuestionsBySubmissionId;

public class GetQuestionsBySubmissionIdQueryHandler(IUnitOfWork unitOfWork,
    IMapper mapper):IRequestHandler<GetQuestionsBySubmissionIdQuery, GetQuestionsBySumissionIdDto>
{
    public async Task<GetQuestionsBySumissionIdDto> Handle(GetQuestionsBySubmissionIdQuery request, CancellationToken cancellationToken)
    {
        var submission = await unitOfWork.Submission.GetOrDefalutAsync(x => x.SubmissionId ==
                                                                      request.submissionId,
            IncludeProperties:"QuestionSets");
        if(submission is null)
            throw new NotFoundException(nameof(submission), request.submissionId);

        var submissionDto = new GetQuestionsBySumissionIdDto();
        submissionDto.SubmissionId = submission.SubmissionId;
        submissionDto.UserId = submission.UserId;
        submission.SubmissionDate = submission.SubmissionDate;
        submissionDto.SampleQuestions = submission.SampleQuestions;
        
        foreach (var questionSet in submission.QuestionSets)
        {
            var (mcqQuestions, matchingQuestions, fillTheBlankQuestions, trueFalseQuestions, status) = 
                await unitOfWork.QuestionSet.GetQuestionsByQuestionSetId(questionSet.QuestionSetId, cancellationToken);

            var questionSetDto = new GetQuestionSetDto
            {
                QuestionSetId = questionSet.QuestionSetId,
                Status = status,
                McqQuestions = mapper.Map<List<McqQuestionsDto>>(mcqQuestions),
                MatchingQuestions = mapper.Map<List<MatchingQuestionsDto>>(matchingQuestions),
                TrueFalseQuestions = mapper.Map<List<TrueFalseQuestionsDto>>(trueFalseQuestions),
                FillTheBlanks = mapper.Map<List<FillTheBlankDto>>(fillTheBlankQuestions)
            };
            
            submissionDto.QuestionSets.Add(questionSetDto);
        }
        return submissionDto;
    }
}