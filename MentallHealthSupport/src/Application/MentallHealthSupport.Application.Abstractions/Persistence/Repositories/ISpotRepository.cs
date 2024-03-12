using MentallHealthSupport.Application.Models.Entities;

namespace MentallHealthSupport.Application.Abstractions.Persistence.Repositories;

public interface ISpotRepository
{
    Task CreateSpot(Spot spot, CancellationToken cancellationToken);
    Task<List<Spot>> GetAvailiblePsychologistSpots(Guid psychologistId, CancellationToken cancellationToken);
    Task<List<Spot>> GetPsychologistSchedule(Guid psychologistId, CancellationToken cancellationToken);
}