using MentallHealthSupport.Infrastructure.Persistence.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MentallHealthSupport.Infrastructure.Persistence.Contexts.Configurations;

public class SessionConfiguration : IEntityTypeConfiguration<SessionModel>
{
    public void Configure(EntityTypeBuilder<SessionModel> builder)
    {
        builder.ToTable("session");
        builder.HasKey(session => session.Id).HasName("sessions_pkey");
        builder.Property(session => session.Id).HasColumnName("session_id").HasColumnType("character varying");
        builder.Property(session => session.Status).HasColumnName("status").HasColumnType("character varying");
        builder.Property(session => session.Price).HasColumnName("cost").HasColumnType("numeric");
        builder.Property(session => session.UserId).HasColumnName("user_id").HasColumnType("character varying");
        builder.Property(session => session.SpotId).HasColumnName("spot_id").HasColumnType("character varying");
        builder.HasOne(session => session.User).WithMany(user => user.Sessions).HasForeignKey(session => session.UserId).HasConstraintName("session_user_user_id_fk");
        builder.HasOne(session => session.Spot)
            .WithOne(spot => spot.Session)
            .HasForeignKey<SessionModel>(spot => spot.SpotId)
            .HasConstraintName("session_spot_spot_id_fk");
    }
}