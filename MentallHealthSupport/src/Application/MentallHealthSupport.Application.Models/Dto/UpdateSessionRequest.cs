namespace MentallHealthSupport.Application.Models.Dto;

public record UpdateSessionRequest(
    Guid Id,
    string? Status,
    decimal? Price
);
