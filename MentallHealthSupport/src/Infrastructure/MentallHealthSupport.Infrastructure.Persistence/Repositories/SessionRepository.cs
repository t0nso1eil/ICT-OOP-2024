using MentallHealthSupport.Application.Abstractions.Persistence.Repositories;
using MentallHealthSupport.Application.Models.Entities;
using MentallHealthSupport.Infrastructure.Persistence.Contexts;
using MentallHealthSupport.Infrastructure.Persistence.Mapping;
using MentallHealthSupport.Infrastructure.Persistence.Models;
using Microsoft.EntityFrameworkCore;

namespace MentallHealthSupport.Infrastructure.Persistence.Repositories;

public class SessionRepository(ApplicationDbContext dbContext) : ISessionRepository
{
    public async Task CreateSession(Session session)
    {
        var sessionModel = MapToModel(session);
        await dbContext.AddAsync(sessionModel);
        await dbContext.SaveChangesAsync();
    }

    public async Task UpdateSessionStatus(Guid sessionId, string newStatus)
    {
        var sessionModel = await dbContext.Sessions.FirstOrDefaultAsync(session => session.Id == sessionId);
        if (sessionModel != null)
        {
            sessionModel.Status = newStatus;
            await dbContext.SaveChangesAsync();
        }
        else
        {
            throw new ArgumentException("Такой сессии нет");
        }
    }

    public async Task<ICollection<Session>> GetUserSessions(Guid userId)
    {
        var userSessions = await dbContext.Sessions
            .Where(session => session.User.Id == userId)
            .ToListAsync();

        return userSessions.Select(sessionModel => MapToEntity(sessionModel)).ToList();
    }

    private Session MapToEntity(SessionModel sessionModel)
    {
        return SessionMapper.ToEntity(sessionModel);
    }

    private Task<SessionModel> MapToModel(Session entity)
    {
        return SessionMapper.ToModel(entity, dbContext);
    }
}