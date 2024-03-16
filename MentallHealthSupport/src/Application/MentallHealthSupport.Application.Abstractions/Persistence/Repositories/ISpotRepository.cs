using MentallHealthSupport.Application.Models.Entities;

namespace MentallHealthSupport.Application.Abstractions.Persistence.Repositories;

public interface ISpotRepository
{
    Task CreateSpot(Spot spot);
    Task<List<Spot>> GetAvailiblePsychologistSpots(Guid psychologistId);
    Task<ICollection<Spot>> GetPsychologistSchedule(Guid psychologistId);
    Task UpdateSpotStatus(Guid spotId, string status);

    Task<Spot> GetSpotById(Guid id);

    Task<ICollection<Spot>> GetPsychologistFreeSpotsById(Guid psychologistId);
}