using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QuesGenie.Domain.Entities;

namespace QuesGenie.Infrastructure.Data.config;

public class QuizResponsesConfigurations:IEntityTypeConfiguration<QuizResponses>
{
    public void Configure(EntityTypeBuilder<QuizResponses> builder)
    {
        builder.HasKey(x => x.ResponseId);
        builder.Property(x => x.ResponseId)
            .HasDefaultValueSql("gen_random_uuid()");

        builder.Property(x => x.UserAnswer)
            .HasColumnType("text");
    }
}