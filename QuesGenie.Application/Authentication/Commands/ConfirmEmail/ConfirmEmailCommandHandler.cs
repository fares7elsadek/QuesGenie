using System.Text;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.WebUtilities;
using QuesGenie.Domain.Entities;
using QuesGenie.Domain.Exceptions;

namespace QuesGenie.Application.Authentication.Commands.ConfirmEmail;

public class ConfirmEmailCommandHandler(UserManager<ApplicationUser> userManager):IRequestHandler<ConfirmEmailCommand,string>
{
    public async Task<string> Handle(ConfirmEmailCommand request, CancellationToken cancellationToken)
    {
        if (string.IsNullOrEmpty(request.Code) || string.IsNullOrEmpty(request.UserId))
        {
            throw new CustomException("Invalid email confirmation request");
        }
        var user = await userManager.FindByIdAsync(request.UserId);
        if (user == null)
            throw new CustomException("Invalid email confirmation request");

        if(await userManager.IsEmailConfirmedAsync(user))
            throw new CustomException("Email is already confirmed");

        var code = Encoding.UTF8.GetString(WebEncoders.Base64UrlDecode(request.Code));
        var result = await userManager.ConfirmEmailAsync(user, code);
        if (!result.Succeeded)
            throw new CustomException("Invalid email confirmation request");

        if(user.LastEmailConfirmationToken != code)
            throw new CustomException("Invalid email confirmation request");

        user.LastEmailConfirmationToken = string.Empty;
        await userManager.UpdateAsync(user);
        
        return "Email confirmed successfully.";
    }
}