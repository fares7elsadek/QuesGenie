using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QuesGenie.Domain.Entities;
using QuesGenie.Domain.Enums;

namespace QuesGenie.Infrastructure.Data.config;

public class QuestionsConfigurations:IEntityTypeConfiguration<Questions>
{
    public void Configure(EntityTypeBuilder<Questions> builder)
    {
        builder.HasKey(x => x.QuestionId);
        builder.Property(x => x.QuestionId)
            .HasDefaultValueSql("gen_random_uuid()");

        builder.Property(x => x.QuestionText)
            .HasColumnType("text")
            .HasDefaultValue("match the following");

        builder.Property(x => x.CreatedAt)
            .HasDefaultValueSql("now()");
        
        builder.Property(x => x.PageRange)
            .HasColumnType("varchar(100)");

        builder.UseTpcMappingStrategy();
        
        builder.HasMany(x => x.QuizResponses)
            .WithOne(x => x.Question)
            .HasForeignKey(x => x.QuestionId)
            .OnDelete(DeleteBehavior.Cascade);
        
    }
}