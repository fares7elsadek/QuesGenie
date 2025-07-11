﻿using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using QuesGenie.Domain.Entities;
using QuesGenie.Domain.Helpers;

namespace QuesGenie.Application.Services.AuthService;

public class AuthService: IAuthService
{
    private readonly JwtOptions jwt;
    private readonly UserManager<ApplicationUser> userManager;
    public AuthService(IOptions<JwtOptions> Jwt,
        UserManager<ApplicationUser> userManager)
    {
        jwt = Jwt.Value;
        this.userManager = userManager;
    }
    
    public async Task<JwtSecurityToken> CreatJwtToken(ApplicationUser user)
    {
        var userClaim = await userManager.GetClaimsAsync(user);
        var role_list = await userManager.GetRolesAsync(user);
        var roleClaims = new List<Claim>();
        foreach (var role in role_list)
            roleClaims.Add(new Claim("role", role));

        var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub,user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Email,user.Email),
                new Claim("uid",user.Id)
            }
            .Union(userClaim)
            .Union(roleClaims);

        var symetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwt.Key));
        var SigningCredentials = new SigningCredentials(symetricSecurityKey,SecurityAlgorithms.HmacSha256);

        var jwtSecurityToken = new JwtSecurityToken(
            issuer:jwt.Issure,
            audience:jwt.Audience,
            claims:claims,
            expires:DateTime.Now.AddMinutes(jwt.DurationInMinutes),
            signingCredentials: SigningCredentials
        );
        return jwtSecurityToken;
    }

    public async Task<AuthResponse> GetJwtToken(ApplicationUser user, List<string> roles)
    {
        AuthResponse authResponse = new AuthResponse();
        var jwtSecurityToken = await CreatJwtToken(user);
        authResponse.Message = "User logged in succeefully";
        authResponse.IsAuthenticated = true;
        authResponse.Email = user.Email;
        authResponse.Username = user.UserName;
        authResponse.Roles = roles;
        authResponse.Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
        if(user.RefreshTokens.Any(x => x.IsActive))
        {
            var activeRefreshToken = user.RefreshTokens.FirstOrDefault(t => t.IsActive);
            authResponse.RefreshToken = activeRefreshToken.Token;
            authResponse.RefreshTokenExpiration = activeRefreshToken.ExpiresOn;
        }
        else
        {
            var token = GenerateRefreshToken();
            authResponse.RefreshToken = token.Token;
            authResponse.RefreshTokenExpiration = token.ExpiresOn;
            user.RefreshTokens.Add(token);
            await userManager.UpdateAsync(user);
        }
        return authResponse;
    }

    public RefreshToken GenerateRefreshToken()
    {
        var randomNumber = new byte[32];
        using (var rng = RandomNumberGenerator.Create())
        {
            rng.GetBytes(randomNumber);
        }
        var token = Convert.ToBase64String(randomNumber);
        return new RefreshToken
        {
            Token= token,
            ExpiresOn = DateTime.UtcNow.AddDays(10),
            CreatedOn = DateTime.UtcNow,
        };
    }
}