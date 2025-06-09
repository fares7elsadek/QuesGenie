using FluentValidation;

namespace QuesGenie.Application.HumanFeedback.Commands.SubmitFeedback;

public class SubmitFeedbackCommandValidator: AbstractValidator<SubmitFeedbackCommand>
{
    public SubmitFeedbackCommandValidator()
    {
        RuleFor(x => x.rate)
            .InclusiveBetween(1,5)
            .WithMessage("Rate must be between 1 and 5");
    }
}