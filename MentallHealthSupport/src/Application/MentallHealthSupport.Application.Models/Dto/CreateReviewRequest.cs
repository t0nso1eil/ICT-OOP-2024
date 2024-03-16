namespace MentallHealthSupport.Application.Models.Dto;

public record CreateReviewRequest
    (Guid UserId,
        Guid PsychologistId, 
        uint Rate, 
        string Description);