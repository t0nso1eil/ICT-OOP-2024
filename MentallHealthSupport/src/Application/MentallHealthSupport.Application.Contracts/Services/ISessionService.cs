using MentallHealthSupport.Application.Models.Dto.Session;
using MentallHealthSupport.Application.Models.Entities;

namespace MentallHealthSupport.Application.Contracts.Services;

public interface ISessionService
{
    Task<string> CreateNewSession(CreateSessionRequest createSessionRequest);

    Task UpdateSessionStatus(Guid id, string status);

    Task<ICollection<Session>> GetUserSessions(Guid userId);
}