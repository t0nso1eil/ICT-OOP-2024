#pragma warning disable IDE0161

namespace MentallHealthSupport.Application.Models.Dto.Review
{
    public record UpdateReviewRequest(uint NewRate, string NewDescription)
    {
        public void UpdateReview(Entities.Review review)
        {
            review.Rate = NewRate;
            review.Description = NewDescription;
        }
    }
}