using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QuesGenie.Domain.Entities;

namespace QuesGenie.Infrastructure.Data.config;

public class QuestionSetConfigurations:IEntityTypeConfiguration<QuestionsSets>
{
    public void Configure(EntityTypeBuilder<QuestionsSets> builder)
    {
        builder.HasKey(x => x.QuestionSetId);
        builder.Property(x => x.QuestionSetId)
            .HasDefaultValueSql("gen_random_uuid()");
        
        builder.Property(x => x.GeneratedAt)
            .HasDefaultValueSql("now()");
        
        builder.HasMany(x => x.Questions)
            .WithOne(x => x.QuestionSet)
            .HasForeignKey(x => x.QuestionSetId)
            .OnDelete(DeleteBehavior.Cascade);
        
        builder.HasMany(x => x.Quizzes)
            .WithOne(x => x.QuestionSet)
            .HasForeignKey(x => x.QuestionSetId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}