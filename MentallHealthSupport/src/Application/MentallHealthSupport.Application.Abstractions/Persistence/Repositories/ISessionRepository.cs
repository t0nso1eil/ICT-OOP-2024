using MentallHealthSupport.Application.Models.Entities;

namespace MentallHealthSupport.Application.Abstractions.Persistence.Repositories;

public interface ISessionRepository
{
    Task CreateNewSession(Session session);
    Task UpdateSessionStatus(Session session, string newStatus);
    Task<List<Session>> GetSessionsByUserId(Guid userId);
    Task<Session> GetSessionById(Guid id);

}