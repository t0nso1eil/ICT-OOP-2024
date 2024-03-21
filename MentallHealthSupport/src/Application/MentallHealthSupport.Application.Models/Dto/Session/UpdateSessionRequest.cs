namespace MentallHealthSupport.Application.Models.Dto.Session;

public record UpdateSessionRequest(
    Guid Id,
    string? Status,
    decimal? Price);
