using MentallHealthSupport.Application.Models.Dto.Review;

namespace MentallHealthSupport.Application.Contracts.Services;

public interface IReviewService
{
    public Task<string> CreateReview(CreateReviewRequest request);

    public Task<string> UpdateReview(Guid reviewId, UpdateReviewRequest request);

    public Task<string> DeleteReview(Guid reviewId);

    public ICollection<PublicReviewInfoResponse> GetPsychologistReviews(Guid psychoId);
}