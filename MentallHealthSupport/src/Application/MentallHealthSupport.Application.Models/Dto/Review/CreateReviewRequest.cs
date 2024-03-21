#pragma warning disable IDE0161

namespace MentallHealthSupport.Application.Models.Dto.Review
{
    public record CreateReviewRequest(
        Guid UserId,
        Guid PsychologistId,
        uint Rate,
        string Description);
}