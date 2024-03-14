using MentallHealthSupport.Application.Models.Entities;
using MentallHealthSupport.Infrastructure.Persistence.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MentallHealthSupport.Infrastructure.Persistence.Contexts.Configurations.Configurations;

public class SpotConfiguration : IEntityTypeConfiguration<SpotModel>
{
    public void Configure(EntityTypeBuilder<SpotModel> builder)
    {
        builder.HasKey(spot => spot.Id).HasName("spots_pkey");
        builder.Property(spot => spot.Id).HasColumnName("spot_id");
        builder.Property(spot => spot.Date).HasColumnName("date");
        builder.Property(spot => spot.HourStart).HasColumnName("hour_start");
        builder.Property(spot => spot.HourEnd).HasColumnName("hour_end");
        builder.Property(spot => spot.Status).HasColumnName("status");
        builder.HasOne(spot => spot.Psychologist).WithMany(psychologist => psychologist.Spots);
        builder.HasOne(spot => spot.Session).WithOne(session => session.Spot);
    }
}