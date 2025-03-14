using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QuesGenie.Domain.Entities;
using QuesGenie.Domain.Enums;

namespace QuesGenie.Infrastructure.Data.config;

public class QuizConfigurations:IEntityTypeConfiguration<Quizzes>
{
    public void Configure(EntityTypeBuilder<Quizzes> builder)
    {
        builder.HasKey(x => x.QuizId);
        builder.Property(x => x.QuizId)
            .HasDefaultValueSql("gen_random_uuid()");

        builder.Property(x => x.SubmitDate)
            .HasDefaultValueSql("now()");
        
        builder.Property(x => x.Status)
            .HasConversion(x => x.ToString()
                ,opt => (QuizStatus)Enum.Parse(typeof(QuizStatus), opt));
        
        builder.HasMany(x => x.Responses)
            .WithOne(x => x.Quiz)
            .HasForeignKey(x => x.QuizId)
            .OnDelete(DeleteBehavior.Cascade);
        
    }
}