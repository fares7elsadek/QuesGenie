using MediatR;

namespace QuesGenie.Application.Authentication.Commands.ResendConfirmationEmail;

public class ResendConfirmationEmailCommand:IRequest<string>
{
    public string Email { get; set; } = default!;
}