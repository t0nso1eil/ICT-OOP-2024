namespace MentallHealthSupport.Application.Models.Dto.Session;

public record CreateSessionRequest(
    string Status,
    decimal Price,
    Guid UserId,
    Guid SpotId);