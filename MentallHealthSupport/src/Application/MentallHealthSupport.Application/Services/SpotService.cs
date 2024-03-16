using MentallHealthSupport.Application.Abstractions.Persistence.Repositories;
using MentallHealthSupport.Application.Contracts;
using MentallHealthSupport.Application.Models.Dto;
using MentallHealthSupport.Application.Models.Entities;
using System;
using System.Collections.Generic;

namespace MentallHealthSupport.Application.Services
{
    public class SpotService : ISpotService
    {
        private readonly ISpotRepository _spotRepository;

        public SpotService(ISpotRepository spotRepository)
        {
            _spotRepository = spotRepository;
        }

        public async Task CreateNewSpot(CreateSpotRequest createSpotRequest)
        {
            var spot = new Spot
            {
                Id = Guid.NewGuid(),
                Date = createSpotRequest.Date,
                HourStart = createSpotRequest.StartTime,
                HourEnd = createSpotRequest.EndTime
            };
            await _spotRepository.CreateSpot(spot);
        }

        public async Task UpdateSpotStatus(Guid spotId, string status)
        {
            var spotToUpdate = await _spotRepository.GetSpotById(spotId);
            await _spotRepository.UpdateSpotStatus(spotId, status);
        }

        public async Task<ICollection<Spot>> GetPsychologistFreeSpots(Guid psychologistId)
        {
            var avalibleSpots = await _spotRepository.GetPsychologistFreeSpotsById(psychologistId);
            return avalibleSpots;
        }

        public async Task <ICollection<Spot>> GetPsychologistSchedule(Guid psychologistId)
        {
            return await _spotRepository.GetPsychologistSchedule(psychologistId);
        }
    }
}