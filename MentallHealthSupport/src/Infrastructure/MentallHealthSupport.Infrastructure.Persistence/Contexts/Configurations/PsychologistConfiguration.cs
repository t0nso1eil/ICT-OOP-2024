using MentallHealthSupport.Infrastructure.Persistence.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MentallHealthSupport.Infrastructure.Persistence.Contexts.Configurations;
public class PsychologistConfiguration : IEntityTypeConfiguration<PsychologistModel>
{
    public void Configure(EntityTypeBuilder<PsychologistModel> builder)
    {
        // прописать то, как все поля и constrains должны выглядеть в бд

        builder.Property(p => p.Id).HasColumnName("psychologist_id");
        builder.Property(p => p.Specialization).HasColumnName("specialization");
        builder.Property(p => p.PricePerHour).HasColumnName("price_per_hour");
        builder.Property(p => p.ExperienceStartDate).HasColumnName("experience_start_date");
        builder.Property(p => p.ExperienceYears).HasColumnName("experience_years");
        builder.Property(p => p.Rate).HasColumnName("rate");
        builder.Property(p => p.User.Id).HasColumnName("user_id");
        
        builder.HasKey(psychologist => psychologist.Id);
        builder.HasOne(psychologist => psychologist.User).WithOne(user => user.Psychologist);
        builder.HasMany(psychologist => psychologist.Reviews).WithOne(review => review.Psychologist);
        builder.HasMany(psychologist => psychologist.Spots).WithOne(spot => spot.Psychologist);
    }
}