using System.Reflection;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using QuesGenie.Domain.Entities;
using QuesGenie.Infrastructure.Data.config;

namespace QuesGenie.Infrastructure.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options)
    :IdentityDbContext<ApplicationUser>(options)
{
    public DbSet<McqQuestions> McqQuestions { get; set; }
    public DbSet<MatchingQuestions> MatchingQuestions { get; set; }
    public DbSet<FillTheBlankQuestions> FillTheBlank { get; set; }
    public DbSet<TrueFalseQuestions> TrueFalseQuestions { get; set; }
    public DbSet<Submissions> Submissions { get; set; }
    public DbSet<Documents> Documents { get; set; }
    public DbSet<MatchingPairs> MatchingPairs { get; set; }
    public DbSet<McqOptions> McqOptions { get; set; }
    public DbSet<Quizzes> Quizzes { get; set; }
    public DbSet<QuizResponses> QuizResponses { get; set; }
    public DbSet<QuestionsSets> QuestionsSets { get; set; }
    public DbSet<Questions> Questions { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        builder.Entity<ApplicationUser>().ToTable("Users");
        builder.Entity<IdentityRole>().ToTable("Roles");
        builder.Entity<IdentityUserRole<string>>().ToTable("UserRoles");
        builder.Entity<IdentityUserClaim<string>>().ToTable("UserClaims");
        builder.Entity<IdentityUserLogin<string>>().ToTable("UserLogins");
        builder.Entity<IdentityRoleClaim<string>>().ToTable("RoleClaims");
        builder.Entity<IdentityUserToken<string>>().ToTable("UserTokens");
    }
}