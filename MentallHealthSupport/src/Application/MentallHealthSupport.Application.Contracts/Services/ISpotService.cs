using MentallHealthSupport.Application.Models.Dto;
using MentallHealthSupport.Application.Models.Entities;

namespace MentallHealthSupport.Application.Contracts.Services;

public interface ISpotService
{
    Task CreateNewSpot(CreateSpotRequest createSpotRequest);

    Task UpdateSpotStatus(Guid spotId, string status);

    Task<ICollection<Spot>> GetPsychologistFreeSpots(Guid psychologistId);

    Task<ICollection<Spot>> GetPsychologistSchedule(Guid psychologistId);
}