using MediatR;
using Microsoft.AspNetCore.Identity;
using QuesGenie.Application.Services.AuthService;
using QuesGenie.Domain.Entities;
using QuesGenie.Domain.Exceptions;
using QuesGenie.Domain.Helpers;

namespace QuesGenie.Application.Authentication.Commands.LoginUser;

public class LoginUserCommandHandler(SignInManager<ApplicationUser> signInManager,
    IAuthService authService,UserManager<ApplicationUser> userManager):IRequestHandler<LoginUserCommand,AuthResponse>
{
    public async Task<AuthResponse> Handle(LoginUserCommand request, CancellationToken cancellationToken)
    {
        var email = request.Email;
        var password = request.Password;
        var user = await userManager.FindByEmailAsync(email);

        if (user == null || user.UserName == null)
            throw new CustomException("Invalid credentials");

        var result = await signInManager.PasswordSignInAsync(user.UserName, password, isPersistent:false ,lockoutOnFailure: true);
        if (result.IsLockedOut)
        {
            throw new CustomException("Account is locked out due to multiple failed attempts. Please try again later.");
        }
        if (!result.Succeeded)
        {
            throw new CustomException("Invalid credentials");
        }
        
        if (!await userManager.IsEmailConfirmedAsync(user))
            throw new CustomException("Please confirm your email first");

        var roles = await userManager.GetRolesAsync(user);
        var authResponse = await authService.GetJwtToken(user, roles.ToList());
        return authResponse;
    }
}