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
            var spot = await CreateSpotEntity(createSpotRequest);
            var spots = await _spotRepository.GetPsychologistFreeSpotsById(createSpotRequest.PsychologistId);
            CheckCorrectTime(spots, spot);
            await _spotRepository.CreateSpot(spot);

            return spot.Id;
        }

        public async Task<PublicSpotInfoResponse> UpdateSpotStatus(UpdateSpotRequest updateSpotRequest)
        {
            var spotToUpdate = await _spotRepository.GetSpotById(updateSpotRequest.Id);

            if (updateSpotRequest.Status != null)
            {
                bool spotIsDefined = Enum.IsDefined(typeof(SessionStatuses), updateSpotRequest.Status);

                if (spotIsDefined)
                {
                    spotToUpdate.Status = updateSpotRequest.Status;
                    await _spotRepository.UpdateSpotStatus(spotToUpdate);
                }
                else
                {
                    throw new IncorrectInputException("Incorrect spot status");
                }
            }
            else
            {
                throw new IncorrectInputException("Session status cannot be null");
            }

            return CreateSpotInfoResponse(spotToUpdate);
        }

        public async Task<ICollection<PublicSpotInfoResponse>> GetPsychologistFreeSpots(Guid psychologistId)
        {
            var availibleSpots = await _spotRepository.GetPsychologistFreeSpotsById(psychologistId);
            return availibleSpots.Select(CreateSpotInfoResponse).ToList();
        }

        public async Task<ICollection<PublicSpotInfoResponse>> GetPsychologistSchedule(Guid psychologistId)
        {
            var schedule =  await _spotRepository.GetPsychologistSchedule(psychologistId);
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
            if (request.Date < DateOnly.FromDateTime(DateTime.Now))
            {
                throw new IncorrectInputException("Incorrect data");
            }

            if (request.StartTime > request.EndTime)
            {
                throw new IncorrectInputException("Incorrect time");
            }
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
            return new PublicSpotInfoResponse(spot.Psychologist.User.FirstName, spot.Psychologist.User.LastName, 
                spot.Date, spot.HourStart, spot.HourEnd, spot.Status);
        }
    }
}