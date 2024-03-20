using MentallHealthSupport.Application.Models.Dto;

namespace MentallHealthSupport.Application.Contracts;

using MentallHealthSupport.Application.Models.Entities;

public interface ISpotService
{
    Task<string> CreateNewSpot(CreateSpotRequest createSpotRequest);

    Task UpdateSpotStatus(UpdateSpotRequest updateSpotRequest);

    Task<ICollection<Spot>> GetPsychologistFreeSpots(Guid psychologistId);

    Task<ICollection<Spot>> GetPsychologistSchedule(Guid psychologistId);
}