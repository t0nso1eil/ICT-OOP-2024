using MentallHealthSupport.Application.Models.Dto;

namespace MentallHealthSupport.Application.Contracts;

using MentallHealthSupport.Application.Models.Entities;

public interface IReviewService
{
    public Task CreateReview(CreateReviewRequest request);

    public Task UpdateReview(Guid reviewId, UpdateReviewRequest request);

    public Task DeleteReview(Guid reviewId);

    public ICollection<PublicReviewInfoResponse> GetPsychologistReviews(Guid reviewId);
}