namespace MentallHealthSupport.Application.Models.Dto;

public record SpotInfo(
    Guid SpotId,
    Guid PsychologistId,
    DateOnly Date,
    DateTime StartTime,
    DateTime EndTime,
    string Status
);
