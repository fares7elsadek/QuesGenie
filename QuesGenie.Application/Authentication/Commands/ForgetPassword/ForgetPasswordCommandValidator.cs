using FluentValidation;

namespace QuesGenie.Application.Authentication.Commands.ForgetPassword;

public class ForgetPasswordCommandValidator:AbstractValidator<ForgetPasswordCommand>
{
    public ForgetPasswordCommandValidator()
    {
        RuleFor(d => d.Email)
            .EmailAddress().WithMessage("Email address is not valid.");
    }
}