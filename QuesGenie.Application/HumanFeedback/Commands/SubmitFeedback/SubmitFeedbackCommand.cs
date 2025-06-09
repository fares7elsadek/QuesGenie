

using MediatR;

namespace QuesGenie.Application.HumanFeedback.Commands.SubmitFeedback;

public record SubmitFeedbackCommand(string questionId, int rate):IRequest;