#pragma warning disable SA1512
#pragma warning disable SA1028

using MentallHealthSupport.Infrastructure.Persistence.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MentallHealthSupport.Infrastructure.Persistence.Contexts.Configurations;
public class PsychologistConfiguration : IEntityTypeConfiguration<PsychologistModel>
{
    public void Configure(EntityTypeBuilder<PsychologistModel> builder)
    {
        builder.Property(p => p.Id).HasColumnName("psychologist_id").HasColumnType("character varying").HasMaxLength(255);
        builder.Property(p => p.UserId).HasColumnName("user_id").HasColumnType("character varying").HasMaxLength(255);
        builder.Property(p => p.Specialization).HasColumnName("specialization").HasColumnType("character varying").HasMaxLength(100);
        builder.Property(p => p.ExperienceYears).HasColumnName("experience_years").HasColumnType("integer");
        builder.Property(p => p.PricePerHour).HasColumnName("price_per_hour").HasColumnType("numeric");
        builder.Property(p => p.ExperienceStartDate).HasColumnName("experience_start_date").HasColumnType("date");
        builder.Property(p => p.Rate).HasColumnName("rate").HasColumnType("numeric");
        builder.HasOne(p => p.User).WithOne(u => u.Psychologist).HasConstraintName("psychologist_user_user_id_fk");
        builder.ToTable("psychologist");
    }
}