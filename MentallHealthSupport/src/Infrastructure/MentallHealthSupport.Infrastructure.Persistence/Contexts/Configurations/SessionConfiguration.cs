using MentallHealthSupport.Infrastructure.Persistence.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MentallHealthSupport.Infrastructure.Persistence.Contexts.Configurations;

public class SessionConfiguration : IEntityTypeConfiguration<SessionModel>
{
    public void Configure(EntityTypeBuilder<SessionModel> builder)
    {
        builder.Property(session => session.Id).HasColumnName("session_id").HasColumnType("character varying").HasMaxLength(255);
        builder.Property(session => session.Status).HasColumnName("status").HasColumnType("character varying").HasMaxLength(50);
        builder.Property(session => session.Price).HasColumnName("cost").HasColumnType("numeric");
        builder.Property(session => session.UserId).HasColumnName("user_id").HasColumnType("character varying").HasMaxLength(255);
        builder.Property(session => session.SpotId).HasColumnName("spot_id").HasColumnType("character varying").HasMaxLength(255);
    }
}