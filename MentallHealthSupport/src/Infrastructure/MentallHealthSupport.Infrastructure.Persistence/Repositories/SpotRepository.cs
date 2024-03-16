using MentallHealthSupport.Infrastructure.Persistence.Contexts.Configurations;

namespace MentallHealthSupport.Infrastructure.Persistence.Repositories;

using MentallHealthSupport.Application.Abstractions.Persistence.Repositories;
using MentallHealthSupport.Application.Models.Entities;
using MentallHealthSupport.Infrastructure.Persistence.Contexts;
using MentallHealthSupport.Infrastructure.Persistence.Mapping;
using MentallHealthSupport.Infrastructure.Persistence.Models;
using Microsoft.EntityFrameworkCore;

public class SpotRepository(ApplicationDbContext dbContext): ISpotRepository
{
    public async Task CreateSpot(Spot spot)
    { 
        var spotModel = MapToModel(spot);
        await dbContext.AddAsync(spotModel);
        await dbContext.SaveChangesAsync();
    }

    public async Task<List<Spot>> GetAvailiblePsychologistSpots(Guid psychologistId)
    {
        var spots = await dbContext.Spots
            .Where(spot => spot.Id == psychologistId && spot.Status == "доступно")
            .ToListAsync();

        if (spots == null)
        {
            throw new Exception("нет свободных окошек для записи");
        }

        return MapToEntity(spots);
    }

    public async Task<ICollection<Spot>> GetPsychologistSchedule(Guid psychologistId)
    {
        var spots = await dbContext.Spots
            .Where(spot => spot.Id == psychologistId)
            .ToListAsync();
        
        return MapToEntity(spots);
    }
    
    public async Task UpdateSpotStatus(Guid spotId, string status)
    {
        var spot = await dbContext.Spots.FindAsync(spotId);

        if (spot == null)
        {
            throw new ArgumentException("Spot not found.");
        }

        spot.Status = status;
        await dbContext.SaveChangesAsync();
    }
    
    public async Task<Spot> GetSpotById(Guid id)
    {
        var spotModel = await dbContext.Spots.FirstOrDefaultAsync(spot => spot.Id == id);
        if (spotModel == null)
        {
            throw new Exception("такой сессии нет");
        }

        return MapToEntity(spotModel);
    }

    public async Task<ICollection<Spot>> GetPsychologistFreeSpotsById(Guid psychologistId)
    {
        var spots = await dbContext.Spots
            .Where(spot => spot.Psychologist.Id == psychologistId && spot.Status == "доступно")
            .ToListAsync();

        var psychologistSpots = spots.Select(spotModel => MapToEntity(spotModel)).ToList();

        return psychologistSpots;
    }

    private List<Spot> MapToEntity(List<SpotModel> models)
    {
        return models.Select(SpotMapper.ToEntity).ToList();
    }

    private Spot MapToEntity(SpotModel model)
    {
        return SpotMapper.ToEntity(model);
    }

    private SpotModel MapToModel(Spot entity)
    {
        return SpotMapper.ToModel(entity);
    }
}