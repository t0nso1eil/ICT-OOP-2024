namespace MentallHealthSupport.Application.Models.Dto;

public record PublicReviewInfoResponse(
    Guid UserId, Guid PsychoId, uint Rate, string Description, DateTime PostTime);