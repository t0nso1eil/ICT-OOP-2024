using MentallHealthSupport.Application.Models.Dto;

namespace MentallHealthSupport.Application.Contracts;

using MentallHealthSupport.Application.Models.Entities;

public interface ISessionService
{
    Task<string> CreateNewSession(CreateSessionRequest createSessionRequest);
    Task UpdateSessionStatus(UpdateSessionRequest updateSessionRequest);
    Task<ICollection<Session>> GetUserSessions(Guid userId); 
}