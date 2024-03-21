using MentallHealthSupport.Application.Models.Dto.Session;

namespace MentallHealthSupport.Application.Contracts.Services;

public interface ISessionService
{
    Task<Guid> CreateNewSession(CreateSessionRequest createSessionRequest);

    Task<PublicSessionInfoResponse> UpdateSessionStatus(Guid id, string status);

    Task<ICollection<PublicSessionInfoResponse>> GetUserSessions(Guid userId);
}