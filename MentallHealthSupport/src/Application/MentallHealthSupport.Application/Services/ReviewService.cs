#pragma warning disable CA1725
#pragma warning disable IDE0161
#pragma warning disable IDE0005
#pragma warning disable IDE0008

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
            var review = createReviewRequest.CreateReview(user, psychologist);
            await _reviewRepository.CreateReview(review);
            return review.Id;
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

        public ICollection<PublicReviewInfoResponse> GetPsychologistReviews(Guid psychoId)
        {
            ICollection<PublicReviewInfoResponse> reviews = _reviewRepository
                .GetAllReviews(psychoId)
                .Select(review => PublicReviewInfoResponse.FromReview(review))
                .ToList();
            return reviews;
        }
    }
}
