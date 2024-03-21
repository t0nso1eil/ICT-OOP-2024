using MentallHealthSupport.Application.Models.Dto.Spot;
using MentallHealthSupport.Application.Models.Entities;

namespace MentallHealthSupport.Application.Contracts.Services;

public interface ISpotService
{
    Task<string> CreateNewSpot(CreateSpotRequest createSpotRequest);

    Task UpdateSpotStatus(UpdateSpotRequest updateSpotRequest);

    Task<ICollection<Spot>> GetPsychologistFreeSpots(Guid psychologistId);

    Task<ICollection<Spot>> GetPsychologistSchedule(Guid psychologistId);
}