using MentallHealthSupport.Application.Models.Entities;

namespace MentallHealthSupport.Application.Abstractions.Persistence.Repositories;

public interface IChatRepository
{
    Task CreateChat(Chat chat, CancellationToken cancellationToken);
    ICollection<Message> GetChatMessages(Chat chat, CancellationToken cancellationToken);
}