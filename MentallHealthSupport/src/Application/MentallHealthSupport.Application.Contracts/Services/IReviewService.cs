using MentallHealthSupport.Application.Models.Entities;

namespace MentallHealthSupport.Application.Contracts.Services;
public interface IReviewService
{
    public void CreateReview(Guid userId, Guid psychologistId, uint rate, string description);

    public void UpdateReview(Guid reviewId, uint rate, string description);

    public void DeleteReview(Guid reviewId);

    public IEnumerable<Review> GetPsychologistReviews(Guid psychologistId);
}