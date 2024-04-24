using MentallHealthSupport.Application.Models.Entities;
using MentallHealthSupport.Infrastructure.Persistence.Contexts;
using MentallHealthSupport.Infrastructure.Persistence.Models;
using Microsoft.EntityFrameworkCore;

namespace MentallHealthSupport.Infrastructure.Persistence.Mapping;

public class SpotMapper(ApplicationDbContext dbContext)
{
    public async Task<Spot> ToEntity(SpotModel spotModel)
    {
        var psychoMapper = new PsychologistMapper(dbContext);
        var spot = new Spot
        {
            Id = spotModel.Id,
            Date = spotModel.Date,
            HourStart = spotModel.HourStart,
            HourEnd = spotModel.HourEnd,
            Status = spotModel.Status, 
            Psychologist = await psychoMapper.ToEntity(await GetPsycho(spotModel.PsychologistId)),
        };
        return spot;
    }

    public SpotModel ToModel(Spot spot)
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

    private async Task<PsychologistModel> GetPsycho(Guid psychoId)
    {
        var user = await dbContext.Psychologists.FirstOrDefaultAsync(u => u.Id == psychoId);
        if (user == null)
        {
            throw new Exception();
        }

        return user;
    }
}