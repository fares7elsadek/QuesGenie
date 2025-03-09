using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QuesGenie.Domain.Entities;

namespace QuesGenie.Infrastructure.Data.config;

public class MatchingPairsConfigurations:IEntityTypeConfiguration<MatchingPairs>
{
    public void Configure(EntityTypeBuilder<MatchingPairs> builder)
    {
        builder.HasKey(x => x.PairId);
        builder.Property(x => x.PairId)
            .HasDefaultValueSql("gen_random_uuid()");

        builder.Property(x => x.LeftSide)
            .HasColumnType("text");
        
        builder.Property(x => x.RightSide)
            .HasColumnType("text");
    }
}