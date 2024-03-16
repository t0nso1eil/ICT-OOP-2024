namespace MentallHealthSupport.Application.Models.Dto;

public record CreateSessionRequest(
    string Status,
    decimal Price,
    Guid UserId,
    Guid SpotId
    );