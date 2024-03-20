using MentallHealthSupport.Application.Models.Entities;

namespace MentallHealthSupport.Application.Models.Dto
{
    public record CreateReviewRequest(Guid UserId, Guid PsychologistId, uint Rate, string Description)
    {
        public Review ToReview()
        {
            return new Review
            {
                Id = Guid.NewGuid(),
                Description = Description,
                Rate = Rate,
                PostTime = DateTime.Now
            };
        }
    }
}