using MentallHealthSupport.Application.Models.Entities;

namespace MentallHealthSupport.Application.Abstractions.Persistence.Repositories;

public interface ISpotRepository
{
    Task CreateSpot(Spot spot);
    Task<ICollection<Spot>> GetPsychologistSchedule(Guid psychologistId);
    Task UpdateSpotStatus(Spot newSpot);
    Task<Spot> GetSpotById(Guid id);
    Task<ICollection<Spot>> GetPsychologistFreeSpotsById(Guid psychologistId);
}