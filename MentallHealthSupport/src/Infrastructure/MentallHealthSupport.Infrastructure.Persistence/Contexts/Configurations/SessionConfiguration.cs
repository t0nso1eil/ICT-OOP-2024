using MentallHealthSupport.Application.Models.Entities;
using MentallHealthSupport.Infrastructure.Persistence.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MentallHealthSupport.Infrastructure.Persistence.Contexts.Configurations
{
    public class SessionConfiguration : IEntityTypeConfiguration<SessionModel>
    {
        public void Configure(EntityTypeBuilder<SessionModel> builder)
        {
            builder.HasKey(session => session.Id).HasName("sessions_pkey");
            builder.Property(session => session.Id).HasColumnName("session_id");
            builder.Property(session => session.Status).HasColumnName("status");
            builder.Property(session => session.Price).HasColumnName("price");
            builder.HasOne(session => session.User).WithMany(user => user.Sessions);
            builder.HasOne(session => session.Spot).WithOne(spot => spot.Session);
        }
    }
}