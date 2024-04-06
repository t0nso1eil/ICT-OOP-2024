using MentallHealthSupport.Application.Abstractions.Persistence.Repositories;
using MentallHealthSupport.Application.Exceptions;
using MentallHealthSupport.Application.Models.Entities;
using MentallHealthSupport.Infrastructure.Persistence.Contexts;
using MentallHealthSupport.Infrastructure.Persistence.Mapping;
using MentallHealthSupport.Infrastructure.Persistence.Models;
using Microsoft.EntityFrameworkCore;

namespace MentallHealthSupport.Infrastructure.Persistence.Repositories;
public class SpotRepository(ApplicationDbContext dbContext) : ISpotRepository
{
    private readonly SpotMapper _mapper = new SpotMapper(dbContext);
    public async Task CreateSpot(Spot spot)
    {
        var spotModel = MapToModel(spot);
        await dbContext.AddAsync(spotModel);
        await dbContext.SaveChangesAsync();
    }

    public async Task<ICollection<Spot>> GetPsychologistSchedule(Guid psychologistId)
    {
        var spots = await dbContext.Spots
            .Where(spot => spot.Id == psychologistId)
            .ToListAsync();

        ICollection<Spot> res = new List<Spot>();
        foreach (var s in spots)
        {
            var e = await MapToEntity(s);
            res.Add(e);
        }

        return res;
    }

    public async Task UpdateSpotStatus(Spot newSpot)
    {
        var spotModel = await dbContext.Sessions.FirstOrDefaultAsync(spot => spot.Id == newSpot.Id);
        if (spotModel != null)
        {
            var newSpotModel = MapToModel(newSpot);
            var currSpot = await dbContext.Spots.FindAsync(newSpotModel.Id);
            dbContext.Entry(currSpot!).CurrentValues.SetValues(newSpotModel);
            await dbContext.SaveChangesAsync();
        }
        else
        {
            throw new NotFoundException("Spot not found");
        }
    }

    public async Task<Spot> GetSpotById(Guid id)
    {
        var spotModel = await dbContext.Spots.FirstOrDefaultAsync(spot => spot.Id == id);
        if (spotModel == null)
        {
            throw new NotFoundException("Spot not found");
        }

        return await MapToEntity(spotModel);
    }

    public async Task<ICollection<Spot>> GetPsychologistFreeSpotsById(Guid psychologistId)
    {
        var spots = await dbContext.Spots
            .Where(spot => spot.PsychologistId == psychologistId && spot.Status == "Availible")
            .ToListAsync();

        ICollection<Spot> res = new List<Spot>();
        foreach (var s in spots)
        {
            var e = await MapToEntity(s);
            res.Add(e);
        }

        return res;
    }

    private async Task<Spot> MapToEntity(SpotModel model)
    {
        return await _mapper.ToEntity(model);
    }

    private SpotModel MapToModel(Spot entity)
    {
        return _mapper.ToModel(entity);
    }
}