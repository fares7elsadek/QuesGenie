using MediatR;
using QuesGenie.Domain.Helpers;

namespace QuesGenie.Application.Authentication.Commands.LoginUser;

public class LoginUserCommand:IRequest<AuthResponse>
{
    public string Email { get; set; } = default!;
    public string Password { get; set; } = default!;
}