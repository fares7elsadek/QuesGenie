using FluentValidation;

namespace QuesGenie.Application.Authentication.Commands.ResendConfirmationEmail;

public class ResendConfirmationEmailCommandValidator:AbstractValidator<ResendConfirmationEmailCommand>
{
    public ResendConfirmationEmailCommandValidator()
    {
        RuleFor(d => d.Email)
            .EmailAddress().WithMessage("Email address is not valid.");
    }
}