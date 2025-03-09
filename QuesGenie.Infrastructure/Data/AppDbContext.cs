using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using QuesGenie.Domain.Entities;
using QuesGenie.Infrastructure.Data.config;

namespace QuesGenie.Infrastructure.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options)
    :IdentityDbContext<ApplicationUser>(options)
{
    public DbSet<Answers> Answers { get; set; }
    public DbSet<Questions> Questions { get; set; }
    public DbSet<Submissions> Submissions { get; set; }
    public DbSet<Documents> Documents { get; set; }
    public DbSet<MatchingPairs> MatchingPairs { get; set; }
    public DbSet<McqOptions> McqOptions { get; set; }
    public DbSet<Quizzes> Quizzes { get; set; }
    public DbSet<QuizResponses> QuizResponses { get; set; }
    public DbSet<QuestionsSets> QuestionsSets { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfigurationsFromAssembly(typeof(AnswersConfigurations).Assembly);
    }
}