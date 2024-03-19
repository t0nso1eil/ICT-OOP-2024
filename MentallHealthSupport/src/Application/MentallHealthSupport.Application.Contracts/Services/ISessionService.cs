using MentallHealthSupport.Application.Models.Dto;
using MentallHealthSupport.Application.Models.Entities;

namespace MentallHealthSupport.Application.Contracts.Services;

public interface ISessionService
{
    Task CreateNewSession(CreateSessionRequest createSessionRequest);

    Task UpdateSessionStatus(Guid id, string newStatus);

    Task<ICollection<Session>> GetUserSessions(Guid userId);
}