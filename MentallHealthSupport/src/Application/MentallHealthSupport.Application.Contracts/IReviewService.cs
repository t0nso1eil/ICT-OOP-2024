namespace MentallHealthSupport.Application.Contracts;

using MentallHealthSupport.Application.Models.Entities;

public interface IReviewService
{
    public void CreateReview(Guid clientId, uint rate, string description);

    public void UpdateReview(Guid reviewId, uint rate, string description);

    public void DeleteReview(Guid reviewId);
    
    public IEnumerable<Review> GetPsychologistReviews(Guid psychologistId);
}