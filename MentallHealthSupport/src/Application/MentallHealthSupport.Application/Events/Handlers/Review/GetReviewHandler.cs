using MentallHealthSupport.Application.Abstractions.Persistence.Repositories;
using MentallHealthSupport.Application.Exceptions;
using MentallHealthSupport.Application.Models.Dto.Review;


namespace MentallHealthSupport.Application.Events.Handlers.Review
{
    public class GetReviewHandler
    {
        private readonly IReviewRepository _reviewRepository;

        public GetReviewHandler(IReviewRepository reviewRepository)
        {
            _reviewRepository = reviewRepository;
        }

        public async Task<PublicReviewInfoResponse> Handle(Guid reviewId)
        {
            var review = await _reviewRepository.GetReviewById(reviewId);

            if (review == null)
            {
                throw new NotFoundException($"Review with ID {reviewId} not found.");
            }

            return PublicReviewInfoResponse.FromReview(review);
        }
    }
}