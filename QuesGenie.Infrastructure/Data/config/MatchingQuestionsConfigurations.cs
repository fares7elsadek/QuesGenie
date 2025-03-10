using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QuesGenie.Domain.Entities;

namespace QuesGenie.Infrastructure.Data.config;

public class MatchingQuestionsConfigurations:IEntityTypeConfiguration<MatchingQuestions>
{
    public void Configure(EntityTypeBuilder<MatchingQuestions> builder)
    {
        builder.HasMany(x => x.MatchingPairs)
            .WithOne(x => x.Question)
            .HasForeignKey(x => x.QuestionId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}