using MentallHealthSupport.Application.Models.Entities;
using MentallHealthSupport.Infrastructure.Persistence.Models;
using MentallHealthSupport.Infrastructure.Persistence.Repositories;

namespace MentallHealthSupport.Infrastructure.Persistence.Mapping;

public class MessageMapper
{
    public static Message ToEntity(MessageModel messageModel)
    {
        return new Message
        {
            Id = messageModel.Id,
            Chat = messageModel.Chat,
            Sender = messageModel.Sender,
            MessageText = messageModel.MessageText,
            SentTime = messageModel.SentTime
        };
    }

    public static MessageModel ToModel(Message message)
    {
        return new MessageModel
        {
            Id = message.Id,
            Chat = message.Chat,
            Sender = message. Sender,
            MessageText = message.MessageText,
            SentTime = message.SentTime
        };

        if (message.Chat != null)
            {
                messageModel.Chat = ChatMapper.ToModel(message.Chat);
            }

        return messageModel;
    }
}