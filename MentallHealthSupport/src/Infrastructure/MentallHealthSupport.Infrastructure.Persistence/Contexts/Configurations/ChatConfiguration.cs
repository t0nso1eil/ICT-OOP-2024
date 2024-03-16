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
            builder.ToTable("chat");
            builder.HasKey(chat => chat.Id).HasName("chats_pkey");
            builder.Property(chat => chat.Id).HasColumnName("chat_id").HasColumnType("character varying");
            builder.Property(chat => chat.Message).HasColumnName("message").HasColumnType("character varying");
            builder.Property(chat => chat.UserId1).HasColumnName("user_id").HasColumnType("character varying");
            builder.Property(chat => chat.UserId2).HasColumnName("user_id").HasColumnType("character varying");
            //builder.HasOne(chat => chat.User1)
            //    .WithMany(user1 => user1.Chats)
            //    .HasForeignKey(user1 => user1.Chats)
            //    .HasConstraintName("chat_user1_user1_id_fk");
            //builder.HasOne(chat => chat.User1)
            //    .WithMany(user2 => user2.Chats)
            //    .HasForeignKey(user2 => user2.Chats)
            //    .HasConstraintName("chat_user2_user2_id_fk");
            builder.HasOne(chat => chat.User1).WithMany(user1 => user1.Chats);
            builder.HasOne(chat => chat.User2).WithMany(user2 => user2.Chats);
            builder.HasOne(chat => chat.Message).WithMany(message => message.Chat);
        }
    }
}