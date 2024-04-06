using MentallHealthSupport.Application.Exceptions;
using MentallHealthSupport.Application.Models.Entities;
using MentallHealthSupport.Infrastructure.Persistence.Contexts;
using MentallHealthSupport.Infrastructure.Persistence.Models;
using Microsoft.EntityFrameworkCore;

namespace MentallHealthSupport.Infrastructure.Persistence.Mapping;

public class SessionMapper(ApplicationDbContext dbContext)
{
    public async Task<Session> ToEntity(SessionModel sessionModel)
    {
        var spotMapper = new SpotMapper(dbContext);
        var session = new Session
        {
            Id = sessionModel.Id,
            Status = sessionModel.Status,
            Price = sessionModel.Price,
            User = UserMapper.ToEntity(await GetUser(sessionModel.UserId)),
            Spot = await spotMapper.ToEntity(await GetSpot(sessionModel.SpotId)),
        };
        return session;
    }

    public SessionModel ToModel(Session session)
    {
        var sessionModel = new SessionModel
        {
            Id = session.Id,
            Status = session.Status,
            Price = session.Price,
            SpotId = session.Spot.Id,
        };
        return sessionModel;
    }
    
    public async Task<SpotModel> GetSpot(Guid spotId)
    {
        var spot = await dbContext.Spots.FirstOrDefaultAsync(s => s.Id == spotId);
        if (spot == null)
        {
            throw new NotFoundException("No such spot");
        }
            
        return spot;
    }

    private async Task<UserModel> GetUser(Guid userId)
    {
        var user = await dbContext.Users.FirstOrDefaultAsync(u => u.Id == userId);
        if (user == null)
        {
            throw new NotFoundException("No such user");
        }

        return user;
    }
}