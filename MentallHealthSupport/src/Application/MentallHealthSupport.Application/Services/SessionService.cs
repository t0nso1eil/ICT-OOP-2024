#pragma warning disable IDE0005

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

    public SessionService(ISessionRepository sessionRepository, ISpotRepository spotRepository)
    {
        _sessionRepository = sessionRepository;
        _spotRepository = spotRepository;
    }

    public async Task<string> CreateNewSession(CreateSessionRequest createSessionRequest)
    {
        var spot = await _spotRepository.GetSpotById(createSessionRequest.SpotId);
        if (spot.Status == "Unavalible")
        {
            throw new ConflictException("Spot is unavalible");
        }

        var session = new Session
        {
            Id = Guid.NewGuid(),
            Status = createSessionRequest.Status,
            Price = createSessionRequest.Price,
        };
        await _sessionRepository.CreateNewSession(session);
        return session.Id.ToString();
    }

    public async Task UpdateSessionStatus(Guid id, string status)
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
    }

    public async Task<ICollection<Session>> GetUserSessions(Guid userId)
    {
        var sessions = await _sessionRepository.GetSessionsByUserId(userId);

        return sessions;
    }
}