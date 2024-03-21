#pragma warning disable IDE0005
#pragma warning disable IDE0161

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

        public SpotService(ISpotRepository spotRepository)
        {
            _spotRepository = spotRepository;
        }

        public async Task<string> CreateNewSpot(CreateSpotRequest createSpotRequest)
        {
            if (createSpotRequest.Date < DateOnly.FromDateTime(DateTime.Now))
            {
                throw new IncorrectInputException("Incorrect data");
            }

            if (createSpotRequest.StartTime > createSpotRequest.EndTime)
            {
                throw new IncorrectInputException("Incorrect time");
            }

            var spot = new Spot
            {
                Id = Guid.NewGuid(),
                Date = createSpotRequest.Date,
                HourStart = createSpotRequest.StartTime,
                HourEnd = createSpotRequest.EndTime,
            };
            var spots = await GetPsychologistSchedule(createSpotRequest.PsychologistId);
            CheckCorrectTime(spots, spot);
            await _spotRepository.CreateSpot(spot);

            return spot.Id.ToString();
        }

        public async Task UpdateSpotStatus(Guid id, string status)
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
        }

        public async Task<ICollection<Spot>> GetPsychologistFreeSpots(Guid psychologistId)
        {
            var avalibleSpots = await _spotRepository.GetPsychologistFreeSpotsById(psychologistId);
            return avalibleSpots;
        }

        public async Task<ICollection<Spot>> GetPsychologistSchedule(Guid psychologistId)
        {
            return await _spotRepository.GetPsychologistSchedule(psychologistId);
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