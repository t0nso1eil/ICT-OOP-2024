using MentallHealthSupport.Application.Models.Entities;

namespace MentallHealthSupport.Application.Contracts.Services;

public interface ISessionService
{
    public void CreateSession(Guid userId, Guid spotId);

    public void UpdateSessionStatus(Guid sessionId, string status);

    public IEnumerable<Session> GetUserSessions(Guid userId);
}