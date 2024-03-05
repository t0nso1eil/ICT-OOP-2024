namespace MentallHealthSupport.Application.Contracts;

using MentallHealthSupport.Application.Models.Entities;

public interface ISessionService
{
    public void CreateSession(Guid userId, Guid spotId);

    public void UpdateSessionStatus(Guid sessionId, string status);

    public IEnumerable<Session> GetUserSessions(Guid userId);
}