using MediatR;
using QuesGenie.Application.GenerateQuestions.QuestionsDtoWithAnswer;

namespace QuesGenie.Application.GenerateQuestions.Queries.GetQuestionsByQuestionSetIdWithAnswers;

public record GetQuestionsByQuestionSetIdWithAnswersQuery(string questionSetId):IRequest<GetQuestionSetAnswerDto>
{
    
}