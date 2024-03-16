#pragma warning disable IDE0008

using MentallHealthSupport.Application.Models.Entities;
using MentallHealthSupport.Infrastructure.Persistence.Contexts;
using MentallHealthSupport.Infrastructure.Persistence.Models;

namespace MentallHealthSupport.Infrastructure.Persistence.Mapping;

public class SpotMapper
{
    public static Spot ToEntity(SpotModel spotModel)
    {
        var spot = new Spot
        {
            Id = spotModel.Id,
            Date = spotModel.Date,
            HourStart = spotModel.HourStart,
            HourEnd = spotModel.HourEnd,
            Status = spotModel.Status,
        };

        var psychologist = PsychologistMapper.ToEntity(spotModel.Psychologist);
        spot.Psychologist = psychologist;

        var session = SessionMapper.ToEntity(spotModel.Session);
        spot.Session = session;

        return spot;
    }

    public static async Task<SpotModel> ToModel(Spot spot, ApplicationDbContext context)
    {
        var spotModel = new SpotModel
        {
            Id = spot.Id,
            Date = spot.Date,
            HourStart = spot.HourStart,
            HourEnd = spot.HourEnd,
            Status = spot.Status,
        };

        var psychologist = await PsychologistMapper.ToModel(spot.Psychologist, context);
        spotModel.Psychologist = psychologist;

        var session = await SessionMapper.ToModel(spot.Session, context);
        spotModel.Session = session;

        return spotModel;
    }
}