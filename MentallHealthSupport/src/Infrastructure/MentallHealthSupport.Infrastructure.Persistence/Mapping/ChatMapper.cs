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
    }
}