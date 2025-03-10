using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QuesGenie.Domain.Entities;

namespace QuesGenie.Infrastructure.Data.config;

public class McqQuestionsConfigurations:IEntityTypeConfiguration<McqQuestions>
{
    public void Configure(EntityTypeBuilder<McqQuestions> builder)
    {
        builder.HasMany(x => x.McqOptions)
            .WithOne(x => x.Question)
            .HasForeignKey(x => x.QuestionId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}