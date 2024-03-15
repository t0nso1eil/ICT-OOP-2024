#pragma warning disable SA1512
#pragma warning disable SA1028

using MentallHealthSupport.Infrastructure.Persistence.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MentallHealthSupport.Infrastructure.Persistence.Contexts.Configurations;
public class UserConfiguration : IEntityTypeConfiguration<UserModel>
{
    public void Configure(EntityTypeBuilder<UserModel> builder)
    {
        // прописать то, как все поля и constrains должны выглядеть в бд
        // builder.HasKey(user => user.Id);
        // builder.HasOne(user => user.Psychologist).WithOne(psycho => psycho.User);
        // builder.HasMany(user => user.Sessions).WithOne(session => session.User);
        // builder.HasMany(user => user.Chats).WithMany(chat => chat.Users);
        // builder.HasMany(user => user.Messages).WithOne(message => message.Sender);
        
        builder.Property(user => user.Id).HasColumnName("user_id").HasColumnType("character varying").HasMaxLength(255);
        builder.Property(user => user.FirstName).HasColumnName("first_name").HasColumnType("character varying").HasMaxLength(255);
        builder.Property(user => user.LastName).HasColumnName("last_name").HasColumnType("character varying").HasMaxLength(255);
        builder.Property(user => user.Email).HasColumnName("email").HasColumnType("character varying").HasMaxLength(255);
        builder.Property(user => user.PhoneNumber).HasColumnName("phone_number").HasColumnType("character varying").HasMaxLength(20);
        builder.Property(user => user.PasswordHash).HasColumnName("password").HasColumnType("character varying").HasMaxLength(255);
        builder.Property(user => user.Birthday).HasColumnName("birthday").HasColumnType("date");
        builder.Property(user => user.Age).HasColumnName("age").HasColumnType("int");
        builder.Property(user => user.Sex).HasColumnName("sex").HasColumnType("character varying").HasMaxLength(1);
        builder.Property(user => user.AdditionalInfo).HasColumnName("additional_info").HasColumnType("text");
        builder.Property(user => user.IsPsychologist).HasColumnName("is_psychologist").HasColumnType("boolean");
        builder.Property(user => user.RegistrationDate).HasColumnName("registration_date").HasColumnType("timestamp without time zone");
        builder.ToTable("user");
    }
}