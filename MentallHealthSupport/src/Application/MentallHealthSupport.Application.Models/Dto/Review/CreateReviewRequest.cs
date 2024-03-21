#pragma warning disable IDE0161

namespace MentallHealthSupport.Application.Models.Dto.Review
{
    public record CreateReviewRequest(Guid UserId, Guid PsychologistId, uint Rate, string Description)
    {
        public Entities.Review ToReview()
        {
            return new Entities.Review
            {
                Id = Guid.NewGuid(),
                Description = Description,
                Rate = Rate,
                PostTime = DateTime.Now,
            };
        }
    }
}