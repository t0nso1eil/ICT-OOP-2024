namespace MentallHealthSupport.Application.Models.Dto.Spot;

public record CreateSpotRequest(
    Guid PsychologistId,
    DateOnly Date,
    DateTime StartTime,
    DateTime EndTime,
    string Status);
