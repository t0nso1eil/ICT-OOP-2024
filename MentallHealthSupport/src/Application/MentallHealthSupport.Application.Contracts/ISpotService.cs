namespace MentallHealthSupport.Application.Contracts;

using MentallHealthSupport.Application.Models.Entities;

public interface IChatService
{
    public void CreateNewSpot(Guid psychologistId, DateOnly date, DateTime start, DateTime end);
    
    public void UpdateSpotStatus(Guid spotId, string status);
    
    public IEnumerable<Spot> GetPsychologistFreeSpots(Guid psychologistId);

    public IEnumerable<Spot> GetPsychologistSchedule(Guid psychologistId);
    
}