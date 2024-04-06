using MentallHealthSupport.Application.Models.Entities;

namespace MentallHealthSupport.Application.Abstractions.Persistence.Repositories;

public interface IReviewRepository
{
    Task CreateReview(Review review);

    Task<Review> GetReviewById(Guid id);

    Task UpdateReview(Review newReview);

    Task DeleteReview(Guid id);

    Task<ICollection<Review>> GetAllReviews(Guid psychoId);
}