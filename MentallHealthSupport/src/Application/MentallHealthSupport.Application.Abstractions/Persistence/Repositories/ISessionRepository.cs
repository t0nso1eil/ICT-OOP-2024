using MentallHealthSupport.Application.Models.Entities;

namespace MentallHealthSupport.Application.Abstractions.Persistence.Repositories;

public interface ISessionRepository
{
    Task<Guid> CreateNewSession(Session session);

    Task UpdateSessionStatus(Session newSession);

    Task<ICollection<Session>> GetSessionsByUserId(Guid userId);

    Task<Session> GetSessionById(Guid id);
}