using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QuesGenie.Domain.Entities;

namespace QuesGenie.Infrastructure.Data.config;

public class ApplicationUserConfigurations:IEntityTypeConfiguration<ApplicationUser>
{
    public void Configure(EntityTypeBuilder<ApplicationUser> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id)
            .HasDefaultValueSql("gen_random_uuid()");

        builder.Property(x => x.LastName)
            .HasColumnType("varchar(100)");
        
        builder.Property(x => x.FirstName)
            .HasColumnType("varchar(100)");
        
        builder.Property(x => x.AvatarUrl)
            .HasColumnType("text");
        
        builder.Property(x => x.AvatarFileName)
            .HasColumnType("varchar(250)");
        
        builder.HasMany(x => x.Submissions)
            .WithOne(x => x.User)
            .HasForeignKey(x => x.UserId)
            .OnDelete(DeleteBehavior.Cascade);
        
        builder.HasMany(x => x.Quizzes)
            .WithOne(x => x.User)
            .HasForeignKey(x => x.UserId)
            .OnDelete(DeleteBehavior.Cascade);
        
        builder.OwnsMany(x => x.RefreshTokens);
    }
}