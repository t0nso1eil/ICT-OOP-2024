#pragma warning disable IDE0008

using MentallHealthSupport.Application.Models.Entities;
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

            // Psychologist = PsychologistMapper.ToEntity(),
        };
        return spot;
    }

    public static SpotModel ToModel(Spot spot)
    {
        var spotModel = new SpotModel
        {
            Id = spot.Id,
            Date = spot.Date,
            HourStart = spot.HourStart,
            HourEnd = spot.HourEnd,
            Status = spot.Status,
            PsychologistId = spot.Psychologist.Id,
        };
        return spotModel;
    }
}