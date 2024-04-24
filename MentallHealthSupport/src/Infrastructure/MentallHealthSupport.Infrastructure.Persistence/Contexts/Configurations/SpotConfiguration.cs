using MentallHealthSupport.Infrastructure.Persistence.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MentallHealthSupport.Infrastructure.Persistence.Contexts.Configurations;

public class SpotConfiguration : IEntityTypeConfiguration<SpotModel>
{
    public void Configure(EntityTypeBuilder<SpotModel> builder)
    {
        builder.Property(spot => spot.Id).HasColumnName("spot_id").HasColumnType("character varying").HasMaxLength(255);
        builder.Property(spot => spot.Date).HasColumnName("date").HasColumnType("date");
        builder.Property(spot => spot.HourStart).HasColumnName("hour_start").HasColumnType("time without timezone");
        builder.Property(spot => spot.HourEnd).HasColumnName("hour_end").HasColumnType("time without timezone");
        builder.Property(spot => spot.Status).HasColumnName("status").HasColumnType("character varying").HasMaxLength(50);
        builder.ToTable("spot");
        
    }
}