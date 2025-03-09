using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QuesGenie.Domain.Entities;

namespace QuesGenie.Infrastructure.Data.config;

public class MCQOptionsConfigurations:IEntityTypeConfiguration<McqOptions>
{
    public void Configure(EntityTypeBuilder<McqOptions> builder)
    {
        builder.HasKey(x => x.OptionId);
        
        builder.Property(x => x.OptionId)
            .HasDefaultValueSql("gen_random_uuid()");
        
        builder.Property(x => x.OptionText)
            .HasColumnType("text");
    }
}