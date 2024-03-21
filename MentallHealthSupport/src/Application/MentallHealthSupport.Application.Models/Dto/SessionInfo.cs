namespace MentallHealthSupport.Application.Models.Dto;

public record SessionInfo(
    Guid Id,
    string Status,
    decimal Price
    );