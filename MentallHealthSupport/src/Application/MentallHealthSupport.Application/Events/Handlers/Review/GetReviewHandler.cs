using MentallHealthSupport.Application.Abstractions.Persistence.Repositories;


namespace MentallHealthSupport.Application.Events.Handlers.Review
{
    public class GetReviewHandler
    {
        private readonly IReviewRepository _reviewRepository;

        public GetReviewHandler(IReviewRepository reviewRepository)
        {
            _reviewRepository = reviewRepository;
        }

        public async Task<Models.Entities.Review> Handle(Guid reviewId)
        {
            var review = await _reviewRepository.GetReviewById(reviewId);

            if (review == null)
            {
                throw new ReviewNotFoundException($"Review with ID {reviewId} not found.");
            }

            return review;
        }
    }
    
    public class ReviewNotFoundException : Exception
    {
        public ReviewNotFoundException(string message) : base(message)
        {
        }
    }
}