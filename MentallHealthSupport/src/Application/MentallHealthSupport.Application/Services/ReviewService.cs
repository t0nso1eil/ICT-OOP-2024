using MentallHealthSupport.Application.Abstractions.Persistence.Repositories;
using MentallHealthSupport.Application.Contracts;
using MentallHealthSupport.Application.Models.Dto;
using MentallHealthSupport.Application.Models.Entities;
using MentallHealthSupport.Application.Exceptions;

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
            if (review == null)
            {
                throw new NotFoundException("Review not found");
            }

            updateReviewRequest.UpdateReview(review);
            await _reviewRepository.UpdateReview(review);
            return review.Id.ToString();
        }

        public async Task<string> DeleteReview(Guid reviewId)
        {
            var review = await _reviewRepository.GetReviewById(reviewId);
            if (review == null)
            {
                throw new NotFoundException("Review not found");
            }

            await _reviewRepository.DeleteReview(reviewId);
            return review.Id.ToString();
        }

        public ICollection<PublicReviewInfoResponse> GetPsychologistReviews(Guid reviewId)
        {
            ICollection<PublicReviewInfoResponse> reviews = _reviewRepository.GetAllReviews(reviewId)
                .Select(r => new PublicReviewInfoResponse(r.User.Id, r.Psychologist.Id, r.Rate, r.Description, r.PostTime)).ToList();
            return reviews;
        }
    }
}
