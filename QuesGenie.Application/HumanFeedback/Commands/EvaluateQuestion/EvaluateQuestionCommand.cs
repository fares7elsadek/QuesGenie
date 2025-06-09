using MediatR;

namespace QuesGenie.Application.HumanFeedback.Commands.EvaluateQuestion;

public record EvaluateQuestionCommand(List<string> questionIds):IRequest;
