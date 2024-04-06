namespace MentallHealthSupport.Application.Models.Dto.Review;

public record UpdateReviewRequest(
    uint? Rate,
    string? Description);