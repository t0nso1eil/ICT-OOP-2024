using MentallHealthSupport.Application.Abstractions.Persistence.Repositories;
using MentallHealthSupport.Application.Contracts;
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

    public async Task UpdateSessionStatus(Session session, string newStatus)
    {
        var sessionToUpdate = await _sessionRepository.GetSessionById(session.Id);
    
        if (sessionToUpdate != null)
        {
            sessionToUpdate.Status = newStatus ?? sessionToUpdate.Status;
        
            await _sessionRepository.UpdateSessionStatus(sessionToUpdate, sessionToUpdate.Status);
        }
        else
        {
            throw new InvalidOperationException("Такой сессии нет");
        }
    }

    public async Task<IEnumerable<Session>> GetUserSessions(Guid userId)
    {
        var sessions = await _sessionRepository.GetSessionsByUserId(userId); // Assuming you have a method to get all sessions asynchronously

        return sessions;
    }

}