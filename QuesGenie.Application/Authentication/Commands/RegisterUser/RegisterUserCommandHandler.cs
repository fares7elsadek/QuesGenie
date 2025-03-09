using System.ComponentModel.DataAnnotations;
using System.Text;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.WebUtilities;
using QuesGenie.Domain.Entities;
using QuesGenie.Domain.Exceptions;
using QuesGenie.Domain.Helpers;
using Serilog;

namespace QuesGenie.Application.Authentication.Commands.RegisterUser;

public class RegisterUserCommandHandler(UserManager<ApplicationUser> userManager,
    IMapper mapper,IHttpContextAccessor httpContextAccessor,LinkGenerator linkGenerator
    ,IEmailSender<ApplicationUser> emailSender):IRequestHandler<RegisterUserCommand,AuthResponse>
{
    public async Task<AuthResponse> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
    {
        if (await userManager.FindByEmailAsync(request.Email) is not null)
            throw new CustomException("User email already exsit");
        

        if (await userManager.FindByNameAsync(request.UserName) is not null)
            throw new CustomException("Username already exsit");
        
        var user = mapper.Map<ApplicationUser>(request);
        var result = await userManager.CreateAsync(user, request.Password);

        if (!result.Succeeded)
        {
            List<string> errors = new List<string>();
            foreach (var error in result.Errors)
            {
                errors.Add(error.Description);
            }
            throw new CustomException(string.Join(',', errors));
        }

        if (httpContextAccessor.HttpContext == null)
            throw new CustomException("Something wrong has happened");

        await userManager.AddToRoleAsync(user, UserRoles.USER);

        try
        {
            await SendConfirmationEmailAsync(user, httpContextAccessor.HttpContext);
        }
        catch (Exception ex)
        {
            Log.Error($"Failed to send confirmation email for user {user.Email}: {ex.Message}");
            throw new CustomException($"Failed to send confirmation email for user {user.Email}: {ex.Message}");
        }



        var authResponse = new AuthResponse
        {
            Email = request.Email,
            Username = request.UserName,
            IsAuthenticated = true,
            Message = "User registered successfully. Please check your email to confirm your account."
        };

        return authResponse;
    }
    
    private async Task SendConfirmationEmailAsync(ApplicationUser user,HttpContext httpContext)
    {
        var code = await userManager.GenerateEmailConfirmationTokenAsync(user);
        user.LastEmailConfirmationToken = code;
        await userManager.UpdateAsync(user);
        code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
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

        await emailSender.SendConfirmationLinkAsync(user,user.Email,confirmEmailUrl);
    }
}