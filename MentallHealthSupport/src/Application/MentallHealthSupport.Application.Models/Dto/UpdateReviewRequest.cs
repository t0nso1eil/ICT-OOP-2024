using MentallHealthSupport.Application.Models.Entities;

namespace MentallHealthSupport.Application.Models.Dto
{
    public record UpdateReviewRequest(uint NewRate, string NewDescription)
    {
        public void UpdateReview(Review review)
        {
            review.Rate = NewRate;
            review.Description = NewDescription;
        }
    }
}