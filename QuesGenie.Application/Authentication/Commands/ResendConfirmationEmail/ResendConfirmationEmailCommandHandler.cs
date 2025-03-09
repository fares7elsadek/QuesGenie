using System.Text;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.WebUtilities;
using QuesGenie.Domain.Entities;
using QuesGenie.Domain.Exceptions;
using Serilog;

namespace QuesGenie.Application.Authentication.Commands.ResendConfirmationEmail;

public class ResendConfirmationEmailCommandHandler(UserManager<ApplicationUser> userManager,
    LinkGenerator linkGenerator,IEmailSender<ApplicationUser> emailSender,
    IHttpContextAccessor httpContextAccessor):IRequestHandler<ResendConfirmationEmailCommand, string>
{
    public async Task<string> Handle(ResendConfirmationEmailCommand request, CancellationToken cancellationToken)
    {
        var user = await userManager.FindByEmailAsync(request.Email);
        if (user == null)
            throw new CustomException("Email is not registered");
        if(await userManager.IsEmailConfirmedAsync(user))
            throw new CustomException("Email is already confirmed");

        if(httpContextAccessor.HttpContext == null)
            throw new CustomException("Something wrong has happened");

        try
        {
            await SendConfirmationEmailAsync(user, httpContextAccessor.HttpContext);
        }
        catch (Exception ex)
        {
            Log.Error($"Failed to resend confirmation email for user {user.Email}: {ex.Message}");
            throw new CustomException($"Failed to resend confirmation email for user {user.Email}: {ex.Message}");
        }
        return "Email sent successfully";
    }
    
    private async Task SendConfirmationEmailAsync(ApplicationUser user, HttpContext httpContext)
    {
        var code = await userManager.GenerateEmailConfirmationTokenAsync(user);
        code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
        user.LastEmailConfirmationToken = code;
        await userManager.UpdateAsync(user);
        var userId = await userManager.GetUserIdAsync(user);
        var routeValues = new RouteValueDictionary()
        {
            ["userId"] = userId,
            ["code"] = code
        };
        var confirmEmailEndpointName = "ConfirmEmail";
        var confirmEmailUrl = linkGenerator.GetUriByName(httpContext, confirmEmailEndpointName, routeValues)
                              ?? throw new NotSupportedException($"Could not find endpoint named '{confirmEmailEndpointName}'.");

        if (user.Email == null)
            throw new CustomException("User email is not defined");

        await emailSender.SendConfirmationLinkAsync(user, user.Email, confirmEmailUrl);
    }
}