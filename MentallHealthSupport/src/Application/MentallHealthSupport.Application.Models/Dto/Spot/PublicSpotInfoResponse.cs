namespace MentallHealthSupport.Application.Models.Dto.Spot;

public record PublicSpotInfoResponse(
    string FirstName,
    string LastName,
    DateOnly Date,
    DateTime StartTime,
    DateTime EndTime,
    string Status
    );