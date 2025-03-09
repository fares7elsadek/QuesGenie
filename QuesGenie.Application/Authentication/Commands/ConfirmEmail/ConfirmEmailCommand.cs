using MediatR;

namespace QuesGenie.Application.Authentication.Commands.ConfirmEmail;

public class ConfirmEmailCommand(string userId,string code):IRequest<string>
{
    public string UserId { get; set; } = userId;
    public string Code { get; set; } = code;
}