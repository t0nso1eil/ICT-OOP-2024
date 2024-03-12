using MentallHealthSupport.Application.Abstractions.Persistence.Repositories;
using MentallHealthSupport.Application.Models.Entities;
using MentallHealthSupport.Infrastructure.Persistence.Contexts.Configurations;
using MentallHealthSupport.Infrastructure.Persistence.Mapping;
using MentallHealthSupport.Infrastructure.Persistence.Models;
using Microsoft.EntityFrameworkCore;

namespace MentallHealthSupport.Infrastructure.Persistence.Repositories;

public class SessionRepository(ApplicationDbContext dbContext) : ISessionRepository
{
    public async Task CreateSession(Session session, CancellationToken cancellationToken)
    {
        var sessionModel = MapToModel(session);
        await dbContext.AddAsync(sessionModel, cancellationToken);
        await dbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task UpdateSessionStatus(Guid sessionId, string newStatus, CancellationToken cancellationToken)
    {
        var sessionModel = await dbContext.Sessions.FirstOrDefaultAsync(session => session.Id == sessionId, cancellationToken);
        if (sessionModel != null)
        {
            sessionModel.Status = newStatus;
            await dbContext.SaveChangesAsync(cancellationToken);
        }
        else
        {
            throw new ArgumentException("Такой сессии нет");
        }
    }
    
    public async Task<List<Session>> GetUserSessions(Guid userId, CancellationToken cancellationToken)
    {
        var userSessions = await dbContext.Sessions
            .Where(session => session.User.Id == userId)
            .ToListAsync(cancellationToken);

        return userSessions.Select(sessionModel => MapToEntity(sessionModel)).ToList();
    }

    private Session MapToEntity(SessionModel sessionModel)
    {
        return SessionMapper.ToEntity(sessionModel);
    }

    private SessionModel MapToModel(Session entity)
    {
        return SessionMapper.ToModel(entity);
    }
}