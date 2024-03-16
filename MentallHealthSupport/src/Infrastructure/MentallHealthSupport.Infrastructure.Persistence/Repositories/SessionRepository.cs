using MentallHealthSupport.Application.Abstractions.Persistence.Repositories;
using MentallHealthSupport.Application.Models.Entities;
using MentallHealthSupport.Infrastructure.Persistence.Contexts.Configurations;
using MentallHealthSupport.Infrastructure.Persistence.Mapping;
using MentallHealthSupport.Infrastructure.Persistence.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;

namespace MentallHealthSupport.Infrastructure.Persistence.Repositories;

public class SessionRepository(ApplicationDbContext dbContext) : ISessionRepository
{
    public async Task CreateNewSession(Session session)
    {
        var sessionModel = MapToModel(session);
        await dbContext.AddAsync(sessionModel);
        await dbContext.SaveChangesAsync();
    }

    public async Task UpdateSessionStatus(Session session, string newStatus)
    {
        var sessionModel = await dbContext.Sessions.FirstOrDefaultAsync(session => session.Id == session.Id);
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

    public async Task<Session> GetSessionById(Guid id)
    {
        var sessionModel = await dbContext.Sessions.FirstOrDefaultAsync(session => session.Id == id);
        if (sessionModel == null)
        {
            throw new Exception("такой сессии нет");
        }

        return MapToEntity(sessionModel);
    }

    public async Task<List<Session>> GetSessionsByUserId(Guid userId)
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

    private SessionModel MapToModel(Session entity)
    {
        return SessionMapper.ToModel(entity);
    }
}