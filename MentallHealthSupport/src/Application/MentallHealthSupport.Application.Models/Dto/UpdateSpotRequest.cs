namespace MentallHealthSupport.Application.Models.Dto;

public record UpdateSpotRequest(
    Guid Id,
    DateOnly? Date,
    DateTime? StartTime,
    DateTime? EndTime,
    string? Status
);
