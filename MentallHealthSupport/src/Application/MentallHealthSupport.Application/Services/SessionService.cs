#pragma warning disable IDE0005
#pragma warning disable IDE0008
#pragma warning disable SA1028

using MentallHealthSupport.Application.Abstractions.Persistence.Repositories;
using MentallHealthSupport.Application.Contracts.Services;
using MentallHealthSupport.Application.Exceptions;
using MentallHealthSupport.Application.Models.Dto.Session;
using MentallHealthSupport.Application.Models.Entities;
using MentallHealthSupport.Application.Models.Entities.Enums;

namespace MentallHealthSupport.Application.Services;

public class SessionService : ISessionService
{
    private readonly ISessionRepository _sessionRepository;
    private readonly ISpotRepository _spotRepository;
    private readonly IUserRepository _userRepository;

    public SessionService(ISessionRepository sessionRepository, ISpotRepository spotRepository, IUserRepository userRepository)
    {
        _sessionRepository = sessionRepository;
        _spotRepository = spotRepository;
        _userRepository = userRepository;
    }

    public async Task<Guid> CreateNewSession(CreateSessionRequest createSessionRequest)
    {
        var spot = await _spotRepository.GetSpotById(createSessionRequest.SpotId);
        if (spot.Status == "Unavalible")
        {
            throw new ConflictException("Spot is unavalible");
        }

        var user = await _userRepository.GetUserById(createSessionRequest.UserId);
        var session = createSessionRequest.ToSession(user, spot);
        await _sessionRepository.CreateNewSession(session);
        return session.Id;
    }

    public async Task<PublicSessionInfoResponse> UpdateSessionStatus(Guid id, string status)
    {
        var sessionToUpdate = await _sessionRepository.GetSessionById(id);
        bool statusIsDefined = Enum.IsDefined(typeof(SessionStatuses), status);
        if (statusIsDefined)
        {
            sessionToUpdate.Status = status;
            await _sessionRepository.UpdateSessionStatus(sessionToUpdate);
        }
        else
        {
            throw new IncorrectInputException("Incorrect session status");
        }

        return PublicSessionInfoResponse.FromSession(sessionToUpdate);
    }

    public async Task<ICollection<PublicSessionInfoResponse>> GetUserSessions(Guid userId)
    {
        var sessions = await _sessionRepository.GetSessionsByUserId(userId);
        return sessions.Select(session => PublicSessionInfoResponse.FromSession(session)).ToList();
    }
}