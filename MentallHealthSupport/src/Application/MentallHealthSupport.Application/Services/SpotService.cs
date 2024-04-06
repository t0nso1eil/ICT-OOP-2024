using MentallHealthSupport.Application.Abstractions.Persistence.Repositories;
using MentallHealthSupport.Application.Contracts.Services;
using MentallHealthSupport.Application.Exceptions;
using MentallHealthSupport.Application.Models.Dto.Spot;
using MentallHealthSupport.Application.Models.Entities;
using MentallHealthSupport.Application.Models.Entities.Enums;

namespace MentallHealthSupport.Application.Services
{
    public class SpotService : ISpotService
    {
        private readonly ISpotRepository _spotRepository;
        private readonly IPsychologistRepository _psychologistRepository;

        public SpotService(ISpotRepository spotRepository, IPsychologistRepository psychologistRepository)
        {
            _spotRepository = spotRepository;
            _psychologistRepository = psychologistRepository;
        }

        public async Task<Guid> CreateNewSpot(CreateSpotRequest createSpotRequest)
        {
            if (createSpotRequest.Date < DateOnly.FromDateTime(DateTime.Now))
            {
                throw new IncorrectInputException("Incorrect data");
            }

            if (createSpotRequest.StartTime > createSpotRequest.EndTime)
            {
                throw new IncorrectInputException("Incorrect time");
            }

            var psychologist = await _psychologistRepository.GetPsychologistById(createSpotRequest.PsychologistId);
            var spot = createSpotRequest.ToSpot(psychologist);
            var spots = await _spotRepository.GetPsychologistSchedule(createSpotRequest.PsychologistId);
            CheckCorrectTime(spots, spot);
            await _spotRepository.CreateSpot(spot);
            return spot.Id;
        }

        public async Task<PublicSpotInfoResponse> UpdateSpotStatus(Guid id, string status)
        {
            var spotToUpdate = await _spotRepository.GetSpotById(id);
            bool spotIsDefined = Enum.IsDefined(typeof(SessionStatuses), status);

            if (spotIsDefined)
            {
                spotToUpdate.Status = status;
                await _spotRepository.UpdateSpotStatus(spotToUpdate);
            }
            else
            {
                throw new IncorrectInputException("Incorrect spot status");
            }

            return PublicSpotInfoResponse.FromSpot(spotToUpdate);
        }

        public async Task<ICollection<PublicSpotInfoResponse>> GetPsychologistFreeSpots(Guid psychologistId)
        {
            var availableSpots = await _spotRepository.GetPsychologistFreeSpotsById(psychologistId);
            return availableSpots.Select(spot => PublicSpotInfoResponse.FromSpot(spot)).ToList();
        }

        public async Task<ICollection<PublicSpotInfoResponse>> GetPsychologistSchedule(Guid psychologistId)
        {
            var schedule = await _spotRepository.GetPsychologistSchedule(psychologistId);
            return schedule.Select(spot => PublicSpotInfoResponse.FromSpot(spot)).ToList();
        }

        private void CheckCorrectTime(ICollection<Spot> spots, Spot spot)
        {
            foreach (var existingSpot in spots)
            {
                if (existingSpot.Date == spot.Date)
                {
                    if ((existingSpot.HourStart >= spot.HourStart && existingSpot.HourStart < spot.HourEnd) ||
                        (existingSpot.HourEnd > spot.HourStart && existingSpot.HourEnd <= spot.HourEnd) ||
                        (existingSpot.HourStart <= spot.HourStart && existingSpot.HourEnd >= spot.HourEnd))
                    {
                        throw new IncorrectInputException("Time conflict detected");
                    }
                }
            }
        }
    }
}