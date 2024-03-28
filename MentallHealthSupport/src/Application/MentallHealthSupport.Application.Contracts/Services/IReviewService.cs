using MentallHealthSupport.Application.Models.Dto.Review;

namespace MentallHealthSupport.Application.Contracts.Services;

public interface IReviewService
{
    public Task<Guid> CreateReview(CreateReviewRequest request);

    public Task<PublicReviewInfoResponse> UpdateReview(Guid reviewId, UpdateReviewRequest request);

    public Task DeleteReview(Guid reviewId);

    public ICollection<PublicReviewInfoResponse> GetPsychologistReviews(Guid psychoId);
}