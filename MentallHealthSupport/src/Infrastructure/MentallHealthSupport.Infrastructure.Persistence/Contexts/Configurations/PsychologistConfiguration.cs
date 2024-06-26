using MentallHealthSupport.Infrastructure.Persistence.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MentallHealthSupport.Infrastructure.Persistence.Contexts.Configurations;
public class PsychologistConfiguration : IEntityTypeConfiguration<PsychologistModel>
{
    public void Configure(EntityTypeBuilder<PsychologistModel> builder)
    {
        builder.HasKey(p => p.Id).HasName("psychologist_pkey");
        builder.Property(p => p.Id).HasColumnName("psychologist_id").HasColumnType("character varying").HasMaxLength(255);
        builder.Property(p => p.UserId).HasColumnName("user_id").HasColumnType("character varying").HasMaxLength(255);
        builder.Property(p => p.Specialization).HasColumnName("specialization").HasColumnType("character varying").HasMaxLength(100);
        builder.Property(p => p.ExperienceYears).HasColumnName("experience_years").HasColumnType("integer");
        builder.Property(p => p.PricePerHour).HasColumnName("price_per_hour").HasColumnType("numeric");
        builder.Property(p => p.ExperienceStartDate).HasColumnName("experience_start_date").HasColumnType("date");
        builder.Property(p => p.Rate).HasColumnName("rate").HasColumnType("numeric");
        builder.ToTable("psychologist");
    }
}