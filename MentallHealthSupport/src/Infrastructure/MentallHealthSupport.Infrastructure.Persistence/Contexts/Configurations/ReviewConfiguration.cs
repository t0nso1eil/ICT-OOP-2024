using MentallHealthSupport.Infrastructure.Persistence.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MentallHealthSupport.Infrastructure.Persistence.Contexts.Configurations;

public class ReviewConfiguration : IEntityTypeConfiguration<ReviewModel>
{
    public void Configure(EntityTypeBuilder<ReviewModel> builder)
    {
        builder.Property(review => review.Id).HasColumnName("review_id").HasColumnType("character varying").HasMaxLength(255);
        builder.Property(review => review.Rate).HasColumnName("rate").HasColumnType("integer");
        builder.Property(review => review.Description).HasColumnName("description").HasColumnType("text");
        builder.Property(review => review.PsychologistId).HasColumnName("psychologist_id").HasColumnType("character varying").HasMaxLength(255);
        builder.Property(review => review.UserId).HasColumnName("user_id").HasColumnType("character varying").HasMaxLength(255);
        builder.Property(review => review.PostTime).HasColumnName("post_time").HasColumnType("timestamp without time zone");
        builder.ToTable("review");
    }
}