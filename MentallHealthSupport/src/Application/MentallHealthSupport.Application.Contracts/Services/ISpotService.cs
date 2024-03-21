using MentallHealthSupport.Application.Models.Dto.Spot;
using MentallHealthSupport.Application.Models.Entities;

namespace MentallHealthSupport.Application.Contracts.Services;

public interface ISpotService
{
    Task<Guid> CreateNewSpot(CreateSpotRequest createSpotRequest);

    Task<PublicSpotInfoResponse> UpdateSpotStatus(UpdateSpotRequest updateSpotRequest);

    Task<ICollection<PublicSpotInfoResponse>> GetPsychologistFreeSpots(Guid psychologistId);

    Task<ICollection<PublicSpotInfoResponse>> GetPsychologistSchedule(Guid psychologistId);
}