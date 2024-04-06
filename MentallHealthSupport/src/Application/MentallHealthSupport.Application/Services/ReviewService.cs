using MentallHealthSupport.Application.Abstractions.Persistence.Repositories;
using MentallHealthSupport.Application.Contracts.Services;
using MentallHealthSupport.Application.Models.Dto.Review;

namespace MentallHealthSupport.Application.Services
{
    public class ReviewService : IReviewService
    {
        private readonly IReviewRepository _reviewRepository;
        private readonly IPsychologistRepository _psychologistRepository;
        private readonly IUserRepository _userRepository;

        public ReviewService(IReviewRepository reviewRepository, IPsychologistRepository psychologistRepository, IUserRepository userRepository)
        {
            _reviewRepository = reviewRepository;
            _psychologistRepository = psychologistRepository;
            _userRepository = userRepository;
        }

        public async Task<Guid> CreateReview(CreateReviewRequest createReviewRequest)
        {
            var user = await _userRepository.GetUserById(createReviewRequest.UserId);
            var psychologist = await _psychologistRepository.GetPsychologistById(createReviewRequest.PsychologistId);
            var review = createReviewRequest.ToReview(user, psychologist);
            return await _reviewRepository.CreateReview(review);
        }

        public async Task<PublicReviewInfoResponse> UpdateReview(Guid reviewId, UpdateReviewRequest updateReviewRequest)
        {
            var review = await _reviewRepository.GetReviewById(reviewId);
            review.Rate = updateReviewRequest.Rate ?? review.Rate;
            review.Description = updateReviewRequest.Description ?? review.Description;
            await _reviewRepository.UpdateReview(review);
            return PublicReviewInfoResponse.FromReview(review);
        }

        public async Task DeleteReview(Guid reviewId)
        {
            await _reviewRepository.DeleteReview(reviewId);
        }

        public async Task<ICollection<PublicReviewInfoResponse>> GetPsychologistReviews(Guid psychoId)
        {
            var reviews = await _reviewRepository.GetAllReviews(psychoId);
            ICollection<PublicReviewInfoResponse> res = reviews.Select(r => PublicReviewInfoResponse.FromReview(r)).ToList();
            return res;
        }
    }
}
