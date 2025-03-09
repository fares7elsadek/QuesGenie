using MediatR;
using QuesGenie.Domain.Helpers;

namespace QuesGenie.Application.Authentication.Commands.CreateRefreshToken;

public class CreateRefreshTokenCommand(string token):IRequest<AuthResponse>
{
    public string Token { get; set; } = token;
}