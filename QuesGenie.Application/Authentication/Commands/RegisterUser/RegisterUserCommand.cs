using MediatR;
using QuesGenie.Domain.Helpers;

namespace QuesGenie.Application.Authentication.Commands.RegisterUser;

public class RegisterUserCommand:IRequest<AuthResponse>
{
    public string FirstName { get; set; } = default!;
    public string LastName { get; set; } = default!;
    public string UserName { get; set; } = default!;
    public string Email { get; set; } = default!;
    public string Password { get; set; } = default!;
}