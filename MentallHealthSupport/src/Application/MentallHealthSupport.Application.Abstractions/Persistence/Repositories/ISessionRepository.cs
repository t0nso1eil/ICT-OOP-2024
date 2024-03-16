using MentallHealthSupport.Application.Models.Entities;

namespace MentallHealthSupport.Application.Abstractions.Persistence.Repositories;

public interface ISessionRepository
{
    Task CreateSession(Session session);

    Task UpdateSessionStatus(Guid sessionId, string newStatus);

    Task<ICollection<Session>> GetUserSessions(Guid userId);
}