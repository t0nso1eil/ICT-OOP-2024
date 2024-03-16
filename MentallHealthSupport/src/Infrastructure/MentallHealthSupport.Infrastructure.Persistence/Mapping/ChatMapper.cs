using MentallHealthSupport.Application.Models.Entities;
using MentallHealthSupport.Infrastructure.Persistence.Models;
using MentallHealthSupport.Infrastructure.Persistence.Repositories;

namespace MentallHealthSupport.Infrastructure.Persistence.Mapping;

public class ChatMapper
{
    public static Chat ToEntity(ChatModel chatModel)
    {
        return new Chat
        {
            Id = chatModel.Id,
            User1 = chatModel.User1,
            User2 = chatModel.User2,
            Messages = chatModel.Messages
        };

        if (chatModel.Messages != null && chatModel.Messages.Any())
        {
            chat.Messages = new List<Message>();
            foreach (var messageModel in chatModel.Messages)
            {
                var message = MessageMapper.ToEntity(messageModel);
                chat.Messages.Add(message);
            }
        }
    }

    public static ChatModel ToModel(Chat chat)
    {
        return new ChatModel
        {
            Id = chat.Id,
            User1 = chat.User1,
            User2 = chat.User2,
            Messages = chat.Messages
        };

        if (chat.Messages != null && chat.Messages.Any())
        {
            chatModel.Messages = new List<MessageModel>();
            foreach (var message in chat.Messages)
            {
                var messageModel = MessageMapper.ToModel(message);
                chatModel.Messages.Add(messageModel);
            }
        }
    }
}