namespace MentallHealthSupport.Application.Models.Dto;

public record DeleteReviewRequest(Guid UserId, Guid PsychologistId, uint Rate, string Description);