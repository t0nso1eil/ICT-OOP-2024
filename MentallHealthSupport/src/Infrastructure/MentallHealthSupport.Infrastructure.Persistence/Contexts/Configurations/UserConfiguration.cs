namespace MentallHealthSupport.Infrastructure.Persistence.Contexts.Configurations;

using MentallHealthSupport.Infrastructure.Persistence.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class UserConfiguration : IEntityTypeConfiguration<UserModel>
{
    public void Configure(EntityTypeBuilder<UserModel> builder)
    {
        // прописать то, как все поля и constrains должны выглядеть в бд
        builder.HasKey(user => user.Id);
        builder.HasOne(user => user.Psychologist).WithOne(psycho => psycho.User);
        builder.HasMany(user => user.Sessions).WithOne(session => session.User);
        builder.HasMany(user => user.Chats).WithMany(chat => chat.Users);
        builder.HasMany(user => user.Messages).WithOne(message => message.Sender);
    }
}