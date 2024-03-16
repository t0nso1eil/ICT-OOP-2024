using MentallHealthSupport.Application.Models.Dto;

namespace MentallHealthSupport.Application.Contracts;

using MentallHealthSupport.Application.Models.Entities;

public interface ISessionService
{
    Task CreateNewSession(CreateSessionRequest createSessionRequest);
    Task UpdateSessionStatus(Session session, string newStatus);
    Task<IEnumerable<Session>> GetUserSessions(Guid userId); 
}