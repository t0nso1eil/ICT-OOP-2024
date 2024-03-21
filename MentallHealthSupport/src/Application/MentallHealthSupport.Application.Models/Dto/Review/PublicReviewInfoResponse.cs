namespace MentallHealthSupport.Application.Models.Dto.Review;

public record PublicReviewInfoResponse(
    Guid UserId, Guid PsychoId, uint Rate, string Description, DateTime PostTime);