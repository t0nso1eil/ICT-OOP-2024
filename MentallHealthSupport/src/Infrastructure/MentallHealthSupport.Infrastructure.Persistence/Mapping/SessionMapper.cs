#pragma warning disable IDE0008

using MentallHealthSupport.Application.Models.Entities;
using MentallHealthSupport.Infrastructure.Persistence.Contexts;
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

    public static async Task<SessionModel> ToModel(Session session, ApplicationDbContext context)
    {
        var sessionModel = new SessionModel
        {
            Id = session.Id,
            Status = session.Status,
            Price = session.Price,
        };
        var user = await UserMapper.ToModel(session.User, context);
        sessionModel.User = user;

        var spot = await SpotMapper.ToModel(session.Spot, context);
        sessionModel.Spot = spot;

        return sessionModel;
    }
}