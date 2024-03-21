#pragma warning disable CA1725
#pragma warning disable IDE0161
#pragma warning disable IDE0005

using MentallHealthSupport.Application.Abstractions.Persistence.Repositories;
using MentallHealthSupport.Application.Contracts.Services;
using MentallHealthSupport.Application.Models.Dto.Review;

namespace MentallHealthSupport.Application.Services
{
    public class ReviewService : IReviewService
    {
        private readonly IReviewRepository _reviewRepository;

        public ReviewService(IReviewRepository reviewRepository)
        {
            _reviewRepository = reviewRepository;
        }

        public async Task<string> CreateReview(CreateReviewRequest createReviewRequest)
        {
            var review = createReviewRequest.ToReview();
            await _reviewRepository.CreateReview(review);
            return review.Id.ToString();
        }

        public async Task<string> UpdateReview(Guid reviewId, UpdateReviewRequest updateReviewRequest)
        {
            var review = await _reviewRepository.GetReviewById(reviewId);
            updateReviewRequest.UpdateReview(review);
            await _reviewRepository.UpdateReview(review);
            return review.Id.ToString();
        }

        public async Task<string> DeleteReview(Guid reviewId)
        {
            var review = await _reviewRepository.GetReviewById(reviewId);
            await _reviewRepository.DeleteReview(reviewId);
            return review.Id.ToString();
        }

        public ICollection<PublicReviewInfoResponse> GetPsychologistReviews(Guid psychoId)
        {
            ICollection<PublicReviewInfoResponse> reviews = _reviewRepository
                .GetAllReviews(psychoId)
                .Select(r => new PublicReviewInfoResponse(r.User.Id, r.Psychologist.Id, r.Rate, r.Description, r.PostTime))
                .ToList();
            return reviews;
        }
    }
}
