using MentallHealthSupport.Application.Models.Entities;
using MentallHealthSupport.Infrastructure.Persistence.Models;

namespace MentallHealthSupport.Infrastructure.Persistence.Mapping;

public class SpotMapper
{
    public static Spot ToEntity(SpotModel spotModel)
    {
        return new Spot
        {
            Id = spotModel.Id,
            //Psychologist = spotModel.PsychologistModel,
            Date = spotModel.Date,
            HourStart = spotModel.HourStart,
            HourEnd = spotModel.HourEnd,
            Status = spotModel.Status,
            //Session = spotModel.SessionModel
        };
    }

    public static SpotModel ToModel(Spot spot)
    {
        return new SpotModel
        {
            Id = spot.Id,
            //Psychologist = spot.PsychologistModel,
            Date = spot.Date,
            HourStart = spot.HourStart,
            HourEnd = spot.HourEnd,
            Status = spot.Status,
            //Session = spot.SessionModel
        };
    }
}