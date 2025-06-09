using MediatR;
using QuesGenie.Application.HumanFeedback.Queries.Dtos;

namespace QuesGenie.Application.HumanFeedback.Queries.GetAllRatedQuestions;

public record GetAllRatedQuestionsQuery():IRequest<List<HumandFeedbackDto>>;
