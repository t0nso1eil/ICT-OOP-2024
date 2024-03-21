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

            var spot = await CreateSpotEntity(createSpotRequest);
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

            return CreateSpotInfoResponse(spotToUpdate);
        }

        public async Task<ICollection<PublicSpotInfoResponse>> GetPsychologistFreeSpots(Guid psychologistId)
        {
            var availableSpots = await _spotRepository.GetPsychologistFreeSpotsById(psychologistId);
            return availableSpots.Select(CreateSpotInfoResponse).ToList();
        }

        public async Task<ICollection<PublicSpotInfoResponse>> GetPsychologistSchedule(Guid psychologistId)
        {
            var schedule = await _spotRepository.GetPsychologistSchedule(psychologistId);
            return schedule.Select(CreateSpotInfoResponse).ToList();
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

        private async Task<Spot> CreateSpotEntity(CreateSpotRequest request)
        {
            return new Spot
            {
                Id = Guid.NewGuid(),
                Psychologist = await _psychologistRepository.GetPsychologistById(request.PsychologistId),
                Date = request.Date,
                HourStart = request.StartTime,
                HourEnd = request.EndTime,
            };
        }

        private PublicSpotInfoResponse CreateSpotInfoResponse(Spot spot)
        {
            return new PublicSpotInfoResponse(spot.Psychologist.User.FirstName,
                spot.Psychologist.User.LastName,
                spot.Date,
                spot.HourStart,
                spot.HourEnd,
                spot.Status);
        }
    }
}