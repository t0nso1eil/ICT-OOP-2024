#pragma warning disable CA1725
#pragma warning disable IDE0161
#pragma warning disable IDE0005

using MentallHealthSupport.Application.Abstractions.Persistence.Repositories;
using MentallHealthSupport.Application.Contracts.Services;
using MentallHealthSupport.Application.Models.Dto.Review;
using MentallHealthSupport.Application.Models.Entities;

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
            var review = await CreateReviewEntity(createReviewRequest);
            await _reviewRepository.CreateReview(review);
            return review.Id;
        }

        public async Task<PublicReviewInfoResponse> UpdateReview(Guid reviewId, UpdateReviewRequest updateReviewRequest)
        {
            var review = await _reviewRepository.GetReviewById(reviewId);
            
            review.Rate = updateReviewRequest.Rate ?? review.Rate;
            review.Description = updateReviewRequest.Description ?? review.Description;
            
            await _reviewRepository.UpdateReview(review);
            return CreateReviewInfoResponse(review);
        }

        public async Task DeleteReview(Guid reviewId)
        {
            var review = await _reviewRepository.GetReviewById(reviewId);
            await _reviewRepository.DeleteReview(reviewId);
        }

        public ICollection<PublicReviewInfoResponse> GetPsychologistReviews(Guid psychoId)
        {
            ICollection<PublicReviewInfoResponse> reviews = _reviewRepository
                .GetAllReviews(psychoId)
                .Select(CreateReviewInfoResponse)
                .ToList();
            return reviews;
        }

        private async Task<Review> CreateReviewEntity(CreateReviewRequest request)
        {
            return new Review
            {
                Id = Guid.NewGuid(),
                Psychologist = await _psychologistRepository.GetPsychologistById(request.PsychologistId),
                User = await _userRepository.GetUserById(request.UserId),
                Description = request.Description,
                Rate = request.Rate,
                PostTime = DateTime.Now,
            };
        }

        private PublicReviewInfoResponse CreateReviewInfoResponse(Review review)
        {
            return new PublicReviewInfoResponse(review.Psychologist.User.FirstName,
                review.Psychologist.User.LastName,
                review.User.FirstName,
                review.User.LastName,
                review.Rate,
                review.Description,
                review.PostTime);
        }
    }
}
