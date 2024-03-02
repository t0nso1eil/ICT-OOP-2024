namespace MentallHealthSupport.Application.Contracts;

public interface ISessionService
{
    public void CreateSession(Guid clientId, Guid spotId);

    public void UpdateSessionStatus(Guid sessionId, string status);
    
    public IEnumerable<Session> GetClientSessions(Guid clientId);
    
}