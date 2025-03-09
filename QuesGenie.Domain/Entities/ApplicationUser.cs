using Microsoft.AspNetCore.Identity;

namespace QuesGenie.Domain.Entities;

public class ApplicationUser:IdentityUser
{
    public ApplicationUser()
    {
        Submissions = new HashSet<Submissions>();
        Quizzes = new HashSet<Quizzes>();
        RefreshTokens = new HashSet<RefreshToken>();
    }
    public string FirstName { get; set; } = default!;
    public string LastName { get; set; } = default!;
    public string? AvatarUrl { get; set; } = default!;
    public string? LastEmailConfirmationToken { get; set; }
    public DateTime? ForgetPasswordResetLinkRequestedAt { get; set; }
    public string? AvatarFileName { get; set; } = default!;
    public ICollection<Submissions> Submissions { get; set; }
    public ICollection<Quizzes> Quizzes { get; set; }
    public ICollection<RefreshToken> RefreshTokens { get; set; }
    
}