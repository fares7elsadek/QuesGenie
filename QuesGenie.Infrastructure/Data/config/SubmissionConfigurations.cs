using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QuesGenie.Domain.Entities;

namespace QuesGenie.Infrastructure.Data.config;

public class SubmissionConfigurations:IEntityTypeConfiguration<Submissions>
{
    public void Configure(EntityTypeBuilder<Submissions> builder)
    {
        builder.HasKey(x => x.SubmissionId);
        builder.Property(x => x.SubmissionId)
            .HasDefaultValueSql("gen_random_uuid()");
        
        builder.Property(x => x.SubmissionDate)
            .HasDefaultValueSql("now()");

        builder.Property(x => x.SampleQuestions)
            .HasColumnType("text");
        
        builder.HasMany(x => x.Documents)
            .WithOne(x => x.Submission)
            .HasForeignKey(x => x.SubmissionId)
            .OnDelete(DeleteBehavior.Cascade);
        
        builder.HasMany(x => x.QuestionSets)
            .WithOne(x => x.Submission)
            .HasForeignKey(x => x.SubmissionId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}