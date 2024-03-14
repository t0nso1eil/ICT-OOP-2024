using MentallHealthSupport.Infrastructure.Persistence.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MentallHealthSupport.Infrastructure.Persistence.Contexts.Configurations;
public class UserConfiguration : IEntityTypeConfiguration<UserModel>
{
    public void Configure(EntityTypeBuilder<UserModel> builder)
    {
        builder.HasKey(user => user.Id).HasName("users_pkey");
        builder.Property(user => user.Id).HasColumnName("user_id");
        builder.Property(user => user.FirstName).HasColumnName("first_name");
        builder.Property(user => user.LastName).HasColumnName("last_name");
        builder.Property(user => user.Email).HasColumnName("email");
        builder.Property(user => user.PhoneNumber).HasColumnName("phone_number");
        builder.Property(user => user.PasswordHash).HasColumnName("password");
        builder.Property(user => user.Birthday).HasColumnName("birthday").HasColumnType("date");
        builder.Property(user => user.Age).HasColumnName("age");
        builder.Property(user => user.Sex).HasColumnName("sex");
        builder.Property(user => user.AdditionalInfo).HasColumnName("additional_info");
        builder.Property(user => user.IsPsychologist).HasColumnName("timestamp without time zone");
        builder.HasOne(user => user.Psychologist).WithOne(psycho => psycho.User);
        builder.HasMany(user => user.Sessions).WithOne(session => session.User);
        builder.HasMany(user => user.Chats).WithMany(chat => chat.Users);
        builder.HasMany(user => user.Messages).WithOne(message => message.Sender);
    }
}