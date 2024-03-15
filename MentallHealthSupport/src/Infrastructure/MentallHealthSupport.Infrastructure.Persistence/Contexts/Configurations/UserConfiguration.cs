using MentallHealthSupport.Infrastructure.Persistence.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MentallHealthSupport.Infrastructure.Persistence.Contexts.Configurations;
public class UserConfiguration : IEntityTypeConfiguration<UserModel>
{
    public void Configure(EntityTypeBuilder<UserModel> builder)
    {
        builder.ToTable("user");
        builder.HasKey(user => user.Id).HasName("users_pkey");
        builder.Property(user => user.Id).HasColumnName("user_id").HasColumnType("character varying");
        builder.Property(user => user.FirstName).HasColumnName("first_name").HasColumnType("character varying");
        builder.Property(user => user.LastName).HasColumnName("last_name").HasColumnType("character varying");
        builder.Property(user => user.Email).HasColumnName("email").HasColumnType("character varying");
        builder.Property(user => user.PhoneNumber).HasColumnName("phone_number").HasColumnType("character varying");
        builder.Property(user => user.PasswordHash).HasColumnName("password").HasColumnType("character varying");
        builder.Property(user => user.Birthday).HasColumnName("birthday").HasColumnType("date");
        builder.Property(user => user.Age).HasColumnName("age").HasColumnType("int");
        builder.Property(user => user.Sex).HasColumnName("sex").HasColumnType("character varying");
        builder.Property(user => user.AdditionalInfo).HasColumnName("additional_info").HasColumnType("text");
        builder.Property(user => user.IsPsychologist).HasColumnName("is_psychologist").HasColumnType("boolean");
        builder.Property(user => user.RegistrationDate).HasColumnName("registration_date").HasColumnType("timestamp without time zone");

        // builder.HasOne(user => user.Psychologist).WithOne(psycho => psycho.User).HasForeignKey<UserModel>(user => user.PsychologistId).HasConstraintName("user_psychologist_psychologist_id_fk");
        // builder.Property(user => user.PsychologistId)
        //     .HasColumnName("psychologist_id")
        //     .HasColumnType("character varying");
        // builder.HasMany(user => user.Sessions).WithOne(session => session.User);
    }
}