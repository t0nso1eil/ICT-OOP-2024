﻿using MentallHealthSupport.Infrastructure.Persistence.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MentallHealthSupport.Infrastructure.Persistence.Contexts.Configurations;

public class ReviewConfiguration : IEntityTypeConfiguration<ReviewModel>
{
    public void Configure(EntityTypeBuilder<ReviewModel> builder)
    {
        builder.ToTable("review");
        builder.HasKey(review => review.Id).HasName("review_pkey");
        builder.Property(review => review.Id).HasColumnName("review_id").HasColumnType("character varying");
        builder.Property(review => review.Rate).HasColumnName("rate").HasColumnType("int");
        builder.Property(review => review.Description).HasColumnName("description").HasColumnType("text");
        builder.Property(review => review.PsychologistId).HasColumnName("psychologist_id").HasColumnType("character varying");
        builder.Property(review => review.UserId).HasColumnName("user_id").HasColumnType("character varying");
        builder.HasOne(review => review.Psychologist).WithMany(psycho => psycho.Reviews).HasForeignKey(review => review.PsychologistId).HasConstraintName("review_psychologist_psychologist_id_fk");
        builder.HasOne(review => review.User).WithMany(user => user.Reviews).HasForeignKey(review => review.UserId).HasConstraintName("review_user_user_id_fk");
    }
}