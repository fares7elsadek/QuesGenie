using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QuesGenie.Domain.Entities;

namespace QuesGenie.Infrastructure.Data.config;

public class AnswersConfigurations:IEntityTypeConfiguration<Answers>
{
    public void Configure(EntityTypeBuilder<Answers> builder)
    {
        builder.HasKey(x => x.AnswerId);
        builder.Property(x => x.AnswerId)
            .HasDefaultValueSql("gen_random_uuid()");

        builder.Property(x => x.AnswerText)
            .HasColumnType("text");

        builder.Property(x => x.CreatedAt)
            .HasDefaultValueSql("now()");
        
    }
}