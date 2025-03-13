using MediatR;
using QuesGenie.Application.GenerateQuestions.Dtos;

namespace QuesGenie.Application.GenerateQuestions.Queries.GetQuestionsByQuestionSetId;

public record GetQuestionsByQuestionSetIdQuery(string questionSetId):IRequest<GetQuestionSetDto>
{
    
}