using MentallHealthSupport.Infrastructure.Persistence.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MentallHealthSupport.Infrastructure.Persistence.Contexts.Configurations;

public class SpotConfiguration : IEntityTypeConfiguration<SpotModel>
{
    public void Configure(EntityTypeBuilder<SpotModel> builder)
    {
        // builder.ToTable("spot");
        // builder.HasKey(spot => spot.Id).HasName("spots_pkey");
        builder.Property(spot => spot.Id).HasColumnName("spot_id").HasColumnType("character varying").HasMaxLength(255);
        builder.Property(spot => spot.Date).HasColumnName("date").HasColumnType("date");
        builder.Property(spot => spot.HourStart).HasColumnName("hour_start").HasColumnType("time without timezone");
        builder.Property(spot => spot.HourEnd).HasColumnName("hour_end").HasColumnType("time without timezone");
        builder.Property(spot => spot.Status).HasColumnName("status").HasColumnType("character varying").HasMaxLength(50);
        builder.ToTable("spot");

        // builder.HasOne(spot => spot.Psychologist).WithMany(psychologist => psychologist.Spots).HasForeignKey(spot => spot.PsychologistId).HasConstraintName("spot_psychologist_psychologist_id_fk");
        // builder.HasOne(spot => spot.Session).WithOne(session => session.Spot).HasForeignKey<SpotModel>(sesion => sesion.SessionId).HasConstraintName("spot_session_session_id_fk");
    }
}