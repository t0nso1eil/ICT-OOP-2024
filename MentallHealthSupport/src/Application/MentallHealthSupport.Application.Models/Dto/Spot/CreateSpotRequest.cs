#pragma warning disable SA1129

namespace MentallHealthSupport.Application.Models.Dto.Spot;

public record CreateSpotRequest(
    Guid PsychologistId,
    DateOnly Date,
    DateTime StartTime,
    DateTime EndTime,
    string Status)
{
    public Entities.Spot ToSpot(Entities.Psychologist psychologist)
    {
        return new Entities.Spot
        {
            Id = new Guid(),
            Psychologist = psychologist,
            Date = Date,
            HourStart = StartTime,
            HourEnd = EndTime,
            Status = Status,
        };
    }
}
