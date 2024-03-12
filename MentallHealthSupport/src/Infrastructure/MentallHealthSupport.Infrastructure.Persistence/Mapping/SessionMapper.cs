using MentallHealthSupport.Application.Models.Entities;
using MentallHealthSupport.Infrastructure.Persistence.Models;

namespace MentallHealthSupport.Infrastructure.Persistence.Mapping;

public class SessionMapper
{
    public static Session ToEntity(SessionModel sessionModel)
    {
        return new Session
        {
            Id = sessionModel.Id,
            User = sessionModel.User,
            Spot = sessionModel.Spot,
            Status = sessionModel.Status,
            Price = sessionModel.Price
        };
    }

    public static SessionModel ToModel(Session session)
    {
        return new SessionModel
        {
            Id = session.Id,
            User = session.User,
            Spot = session.Spot,
            Status = session.Status,
            Price = session.Price
        };
    }
}