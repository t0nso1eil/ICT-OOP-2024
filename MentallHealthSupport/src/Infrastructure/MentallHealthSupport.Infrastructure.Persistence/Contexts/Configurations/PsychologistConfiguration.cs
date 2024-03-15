using MentallHealthSupport.Infrastructure.Persistence.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MentallHealthSupport.Infrastructure.Persistence.Contexts.Configurations;
public class PsychologistConfiguration : IEntityTypeConfiguration<PsychologistModel>
{
    public void Configure(EntityTypeBuilder<PsychologistModel> builder)
    {
        builder.ToTable("psychologist");
        builder.HasOne(p => p.User).WithOne(user => user.Psychologist).HasForeignKey<PsychologistModel>(p => p.UserId).HasConstraintName("psychologist_user_user_id_fk");
        builder.Property(psycho => psycho.Id).HasColumnName("psychologist_id").HasColumnType("character varying");
        builder.Property(p => p.Specialization).HasColumnName("specialization").HasColumnType("character varying");
        builder.Property(p => p.PricePerHour).HasColumnName("price_per_hour").HasColumnType("numeric");
        builder.Property(p => p.ExperienceStartDate).HasColumnName("experience_start_date").HasColumnType("date");
        builder.Property(p => p.ExperienceYears).HasColumnName("experience_years").HasColumnType("int");
        builder.Property(p => p.Rate).HasColumnName("rate").HasColumnType("numeric");
        builder.HasKey(psychologist => psychologist.Id).HasName("psychologist_pkey");
        builder.HasMany(psychologist => psychologist.Reviews).WithOne(review => review.Psychologist);
        builder.HasMany(psychologist => psychologist.Spots).WithOne(spot => spot.Psychologist);
    }
}