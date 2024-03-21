using MentallHealthSupport.Application.Abstractions.Persistence.Repositories;
using MentallHealthSupport.Application.Contracts;
using MentallHealthSupport.Application.Exceptions;
using MentallHealthSupport.Application.Models.Dto;
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

    public async Task UpdateSessionStatus(UpdateSessionRequest updateSessionRequest)
    {
        var sessionToUpdate = await _sessionRepository.GetSessionById(updateSessionRequest.Id);

        if (updateSessionRequest.Status != null)
        {
            bool statusIsDefined = Enum.IsDefined(typeof(SessionStatuses), updateSessionRequest.Status);

            if (statusIsDefined)
            {
                sessionToUpdate.Status = updateSessionRequest.Status;
                await _sessionRepository.UpdateSessionStatus(sessionToUpdate);

            }
            else
            {
                throw new IncorrectInputException("Incorrect session status");
            }
        }
        else
        {
            throw new IncorrectInputException("Session status cannot be null");
        }
    }

    public async Task<ICollection<SessionInfo>> GetUserSessions(Guid userId)
    {
        var sessions = await _sessionRepository.GetSessionsByUserId(userId);
        var sessionInfos = new List<SessionInfo>();

        foreach (var session in sessions)
        {
            sessionInfos.Add(new SessionInfo(
                Id: session.Id,
                Status: session.Status,
                Price: session.Price
            ));
        }

        return sessionInfos;
    }


}