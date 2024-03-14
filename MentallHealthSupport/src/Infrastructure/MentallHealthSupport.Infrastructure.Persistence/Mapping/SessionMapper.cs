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
        };

        var user = UserMapper.ToEntity(sessionModel.User);
        session.User = user;

        var spot = SpotMapper.ToEntity(sessionModel.Spot);
        session.Spot = spot;

        return session;
    }

    public static SessionModel ToModel(Session session)
    {
        var sessionModel = new SessionModel
        {
            Id = session.Id,
            Status = session.Status,
            Price = session.Price
        };
        var user = UserMapper.ToModel(session.User);
        sessionModel.User = user;

        var spot = SpotMapper.ToModel(session.Spot);
        sessionModel.Spot = spot;

        return sessionModel;
    }
}