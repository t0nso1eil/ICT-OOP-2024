namespace MentallHealthSupport.Application.Models.Dto.Spot;

public record UpdateSpotRequest(
    Guid Id,
    DateOnly? Date,
    DateTime? StartTime,
    DateTime? EndTime,
    string? Status);
