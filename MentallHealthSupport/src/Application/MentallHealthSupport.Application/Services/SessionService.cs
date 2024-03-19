using MentallHealthSupport.Application.Abstractions.Persistence.Repositories;
using MentallHealthSupport.Application.Contracts.Services;
using MentallHealthSupport.Application.Models.Dto;
using MentallHealthSupport.Application.Models.Entities;

namespace MentallHealthSupport.Application.Services;

public class SessionService : ISessionService
{
    private readonly ISessionRepository _sessionRepository;

    public SessionService(ISessionRepository sessionRepository)
    {
        _sessionRepository = sessionRepository;
    }

    public async Task CreateNewSession(CreateSessionRequest createSessionRequest)
    {
        var session = new Session
        {
            Id = Guid.NewGuid(),
            Status = createSessionRequest.Status,
            Price = createSessionRequest.Price,
        };
        await _sessionRepository.CreateNewSession(session);
    }

    public async Task UpdateSessionStatus(Guid id, string newStatus)
    {
        var session = await _sessionRepository.GetSessionById(id);
        if (session is null)
        {
            throw new InvalidOperationException("Такой сессии нет");
        }

        await _sessionRepository.UpdateSessionStatus(id, newStatus);
    }

    public async Task<ICollection<Session>> GetUserSessions(Guid userId)
    {
        var sessions = await _sessionRepository.GetSessionsByUserId(userId);

        return sessions;
    }
}