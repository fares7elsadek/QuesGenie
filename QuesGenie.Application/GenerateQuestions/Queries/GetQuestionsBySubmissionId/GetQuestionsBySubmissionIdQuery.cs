using MediatR;
using QuesGenie.Application.GenerateQuestions.Dtos;

namespace QuesGenie.Application.GenerateQuestions.Queries.GetQuestionsBySubmissionId;

public record GetQuestionsBySubmissionIdQuery(string submissionId):IRequest<GetQuestionsBySumissionIdDto>
{
    
}