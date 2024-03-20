using MentallHealthSupport.Application.Models.Dto;

namespace MentallHealthSupport.Application.Contracts;

using MentallHealthSupport.Application.Models.Entities;

public interface IReviewService
{
    public Task<string> CreateReview(CreateReviewRequest request);

    public Task<string> UpdateReview(Guid reviewId, UpdateReviewRequest request);

    public Task<string> DeleteReview(Guid reviewId);

    public ICollection<PublicReviewInfoResponse> GetPsychologistReviews(Guid reviewId);
}