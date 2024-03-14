using MentallHealthSupport.Application.Models.Entities;
using MentallHealthSupport.Infrastructure.Persistence.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MentallHealthSupport.Infrastructure.Persistence.Contexts.Configurations
{
    public class ChatConfiguration : IEntityTypeConfiguration<ChatModel>
    {
        public void Configure(EntityTypeBuilder<ChatModel> builder)
        {
            builder.HasKey(chat => chat.Id).HasName("chats_pkey");
            builder.Property(chat => chat.Id).HasColumnName("chat_id");
            builder.HasOne(chat => chat.User1).WithMany(user1 => user1.Chats);
            builder.HasOne(chat => chat.User2).WithMany(user2 => user2.Chats);
            builder.HasOne(chat => chat.Message).WithMany(message => message.Chat);
        }
    }
}