#pragma warning disable IDE0008

using MentallHealthSupport.Application.Models.Entities;
using MentallHealthSupport.Infrastructure.Persistence.Models;

namespace MentallHealthSupport.Infrastructure.Persistence.Mapping;

public class SessionMapper
{
    public static Session ToEntity(SessionModel sessionModel)
    {
        var session = new Session
        {
            Id = sessionModel.Id,
            Status = sessionModel.Status,
            Price = sessionModel.Price,

            // User = UserMapper.ToEntity(user),
            // Spot = SpotMapper.ToEntity(spot),
        };
        return session;
    }

    public static SessionModel ToModel(Session session)
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
}