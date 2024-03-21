using MentallHealthSupport.Application.Abstractions.Persistence.Repositories;
using MentallHealthSupport.Application.Exceptions;
using MentallHealthSupport.Application.Models.Entities;
using MentallHealthSupport.Infrastructure.Persistence.Contexts;
using MentallHealthSupport.Infrastructure.Persistence.Mapping;
using MentallHealthSupport.Infrastructure.Persistence.Models;
using Microsoft.EntityFrameworkCore;

namespace MentallHealthSupport.Infrastructure.Persistence.Repositories;

public class SessionRepository(ApplicationDbContext dbContext) : ISessionRepository
{
    public async Task CreateNewSession(Session session)
    {
        var sessionModel = MapToModel(session);
        await dbContext.AddAsync(sessionModel);
        await dbContext.SaveChangesAsync();
    }

    public async Task UpdateSessionStatus(Session newSession)
    {
        var sessionModel = await dbContext.Sessions.FirstOrDefaultAsync(session => session.Id == newSession.Id);
        if (sessionModel != null)
        {
            var newSessionModel = MapToModel(newSession);
            var currSession = await dbContext.Sessions.FindAsync(newSessionModel.Id);
            dbContext.Entry(currSession!).CurrentValues.SetValues(newSessionModel);
            await dbContext.SaveChangesAsync();
        }
        else
        {
            throw new NotFoundException("Session not found");
        }
    }

    public async Task<Session> GetSessionById(Guid id)
    {
        var sessionModel = await dbContext.Sessions.FirstOrDefaultAsync(session => session.Id == id);
        if (sessionModel == null)
        {
            throw new NotFoundException("Session not found");
        }

        return MapToEntity(sessionModel);
    }

    public async Task<ICollection<Session>> GetSessionsByUserId(Guid userId)
    {
        ICollection<SessionModel> userSessions = await dbContext.Sessions
            .Where(session => session.User.Id == userId)
            .ToListAsync();

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