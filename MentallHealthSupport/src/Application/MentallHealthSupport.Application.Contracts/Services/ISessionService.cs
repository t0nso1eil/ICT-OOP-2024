using MentallHealthSupport.Application.Models.Dto.Session;
using MentallHealthSupport.Application.Models.Entities;

namespace MentallHealthSupport.Application.Contracts.Services;

public interface ISessionService
{
    Task<Guid> CreateNewSession(CreateSessionRequest createSessionRequest);

    Task<PublicSessionInfoResponse> UpdateSessionStatus(UpdateSessionRequest updateSessionRequest);

    Task<ICollection<PublicSessionInfoResponse>> GetUserSessions(Guid userId);
}