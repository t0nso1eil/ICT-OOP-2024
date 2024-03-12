using MentallHealthSupport.Application.Models.Entities;

namespace MentallHealthSupport.Application.Abstractions.Persistence.Repositories;

public interface ISessionRepository
{
    Task CreateSession(Session session, CancellationToken cancellationToken);
    Task UpdateSessionStatus(Session session, string newStatus, CancellationToken cancellationToken);
    Task GetUserSessions(Session session, CancellationToken cancellationToken);
}