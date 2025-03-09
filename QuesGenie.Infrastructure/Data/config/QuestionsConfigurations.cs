using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QuesGenie.Domain.Entities;

namespace QuesGenie.Infrastructure.Data.config;

public class QuestionsConfigurations:IEntityTypeConfiguration<Questions>
{
    public void Configure(EntityTypeBuilder<Questions> builder)
    {
        builder.HasKey(x => x.QuestionId);
        builder.Property(x => x.QuestionId)
            .HasDefaultValueSql("gen_random_uuid()");

        builder.Property(x => x.QuestionText)
            .HasColumnType("text");

        builder.Property(x => x.CreatedAt)
            .HasDefaultValueSql("now()");
        
        builder.Property(x => x.PageRange)
            .HasColumnType("varchar(100)");
        
        builder.HasMany(x => x.MCQOptions)
            .WithOne(x => x.Question)
            .HasForeignKey(x => x.QuestionId)
            .OnDelete(DeleteBehavior.Cascade);
        
        builder.HasMany(x => x.Answers)
            .WithOne(x => x.Question)
            .HasForeignKey(x => x.QuestionId)
            .OnDelete(DeleteBehavior.Cascade);
        
        builder.HasMany(x => x.MatchingPairs)
            .WithOne(x => x.Question)
            .HasForeignKey(x => x.QuestionId)
            .OnDelete(DeleteBehavior.Cascade);
        
        builder.HasMany(x => x.QuizResponses)
            .WithOne(x => x.Question)
            .HasForeignKey(x => x.QuestionId)
            .OnDelete(DeleteBehavior.Cascade);
        
    }
}