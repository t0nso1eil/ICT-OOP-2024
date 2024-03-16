using MentallHealthSupport.Application.Models.Entities;

namespace MentallHealthSupport.Application.Abstractions.Persistence.Repositories;

public interface IMessageRepository
{
    Task CreateMessage(Message message, CancellationToken cancellationToken);
    Task UpdateMessage(Message message, CancellationToken cancellationToken);
    Task DeleteMessage(Message message, CancellationToken cancellationToken);
}