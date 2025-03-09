using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QuesGenie.Domain.Entities;

namespace QuesGenie.Infrastructure.Data.config;

public class DocumentsConfigurations:IEntityTypeConfiguration<Documents>
{
    public void Configure(EntityTypeBuilder<Documents> builder)
    {
        builder.HasKey(x => x.DocumentId);
        builder.Property(x => x.DocumentId)
            .HasDefaultValueSql("gen_random_uuid()");
        
        builder.Property(x => x.UploadedAt)
            .HasDefaultValueSql("now()");

        builder.Property(x => x.FileUrl)
            .HasColumnType("text");
        
        builder.Property(x => x.Content)
            .HasColumnType("text");
        
        builder.HasOne(x => x.QuestionSet)
            .WithOne(x => x.Document)
            .HasForeignKey<QuestionsSets>(x => x.DocumentId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}