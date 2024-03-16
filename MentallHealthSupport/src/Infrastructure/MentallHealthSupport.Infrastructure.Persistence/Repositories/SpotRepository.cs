#pragma warning disable IDE0051
#pragma warning disable IDE0005

using MentallHealthSupport.Application.Abstractions.Persistence.Repositories;
using MentallHealthSupport.Application.Models.Entities;
using MentallHealthSupport.Infrastructure.Persistence.Contexts;
using MentallHealthSupport.Infrastructure.Persistence.Mapping;
using MentallHealthSupport.Infrastructure.Persistence.Models;
using Microsoft.EntityFrameworkCore;

namespace MentallHealthSupport.Infrastructure.Persistence.Repositories;
public class SpotRepository(ApplicationDbContext dbContext) : ISpotRepository
{
    public async Task CreateSpot(Spot spot, CancellationToken cancellationToken)
    {
        var spotModel = MapToModel(spot);
        await dbContext.AddAsync(spotModel, cancellationToken);
        await dbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task<List<Spot>> GetAvailiblePsychologistSpots(
        Guid psychologistId,
        CancellationToken cancellationToken)
    {
        var spots = await dbContext.Spots
            .Where(spot => spot.Id == psychologistId && spot.Status == "доступно")
            .ToListAsync(cancellationToken);

        if (spots == null)
        {
            throw new Exception("нет свободных окошек для записи");
        }

        return MapToEntity(spots);
    }

    public async Task<List<Spot>> GetPsychologistSchedule(
        Guid psychologistId,
        CancellationToken cancellationToken)
    {
        var spots = await dbContext.Spots
            .Where(spot => spot.Id == psychologistId)
            .ToListAsync(cancellationToken);

        return MapToEntity(spots);
    }

    private List<Spot> MapToEntity(List<SpotModel> models)
    {
        return models.Select(SpotMapper.ToEntity).ToList();
    }

    private Spot MapToEntity(SpotModel model)
    {
        return SpotMapper.ToEntity(model);
    }

    private Task<SpotModel> MapToModel(Spot entity)
    {
        return SpotMapper.ToModel(entity, dbContext);
    }
}