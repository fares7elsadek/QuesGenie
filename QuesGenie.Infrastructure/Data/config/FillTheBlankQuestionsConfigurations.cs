using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QuesGenie.Domain.Entities;

namespace QuesGenie.Infrastructure.Data.config;

public class FillTheBlankQuestionsConfigurations:IEntityTypeConfiguration<FillTheBlankQuestions>
{
    public void Configure(EntityTypeBuilder<FillTheBlankQuestions> builder)
    {
        builder.Property(x => x.AnswerText)
            .HasColumnType("text");
        
    }
}