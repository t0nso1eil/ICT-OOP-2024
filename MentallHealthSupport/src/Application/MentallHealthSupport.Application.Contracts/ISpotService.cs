using MentallHealthSupport.Application.Models.Dto;

namespace MentallHealthSupport.Application.Contracts;

using MentallHealthSupport.Application.Models.Entities;

public interface ISpotService
{
    Task CreateNewSpot(CreateSpotRequest createSpotRequest);

    Task UpdateSpotStatus(Guid spotId, string status);

    Task<ICollection<Spot>> GetPsychologistFreeSpots(Guid psychologistId);

    Task<ICollection<Spot>> GetPsychologistSchedule(Guid psychologistId);
}