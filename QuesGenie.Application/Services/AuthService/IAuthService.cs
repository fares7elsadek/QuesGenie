using System.IdentityModel.Tokens.Jwt;
using QuesGenie.Domain.Entities;
using QuesGenie.Domain.Helpers;

namespace QuesGenie.Application.Services.AuthService;

public interface IAuthService
{
    Task<JwtSecurityToken> CreatJwtToken(ApplicationUser user);
    Task<AuthResponse> GetJwtToken(ApplicationUser user,List<string> roles);
    RefreshToken GenerateRefreshToken();
}