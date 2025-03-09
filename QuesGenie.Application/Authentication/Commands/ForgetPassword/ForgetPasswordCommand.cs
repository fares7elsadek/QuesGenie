using MediatR;

namespace QuesGenie.Application.Authentication.Commands.ForgetPassword;

public class ForgetPasswordCommand:IRequest<string>
{
    public string Email { get; set; } = default!;
}