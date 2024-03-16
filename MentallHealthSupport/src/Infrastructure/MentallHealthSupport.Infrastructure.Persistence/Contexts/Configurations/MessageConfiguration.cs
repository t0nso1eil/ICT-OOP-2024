using MentallHealthSupport.Application.Models.Entities;
using MentallHealthSupport.Infrastructure.Persistence.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MentallHealthSupport.Infrastructure.Persistence.Contexts.Configurations
{
    public class MessageConfiguration : IEntityTypeConfiguration<MessageModel>
    {
        public void Configure(EntityTypeBuilder<MessageModel> builder)
        {
            builder.ToTable("message");
            builder.HasKey(message => message.Id).HasName("messages_pkey");
            builder.Property(message => message.Id).HasColumnName("message_id").HasColumnType("character varying");
            builder.Property(message => message.MessageText).HasColumnName("message_text").HasColumnType("character varying");
            builder.Property(message => message.SentTime).HasColumnName("sent_time").HasColumnType("time without timezone");
            builder.HasOne(chat => chat.Message).WithMany(message => message.Chat);
            builder.HasOne(chat => chat.Sender).WithOne(sender => sender.Chat);
        }
    }
}