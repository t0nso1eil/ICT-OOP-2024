using MentallHealthSupport.Application.Abstractions.Persistence.Repositories;
using MentallHealthSupport.Application.Contracts.Services;
using MentallHealthSupport.Application.Models.Dto;
using MentallHealthSupport.Application.Models.Entities;

namespace MentallHealthSupport.Application.Services;

public class ReviewService : IReviewService
{
    private readonly IReviewRepository _reviewRepository;
    private readonly IUserRepository _userRepository;
    private readonly IPsychologistRepository _psychoRepository;

    public ReviewService(IReviewRepository reviewRepository, IUserRepository userRepository, IPsychologistRepository psychologistRepository)
    {
        _reviewRepository = reviewRepository;
        _userRepository = userRepository;
        _psychoRepository = psychologistRepository;
    }

    public async Task CreateReview(CreateReviewRequest request)
    {
        var review = new Review
        {
            Id = Guid.NewGuid(),
            Description = request.Description,
            Rate = request.Rate,
            PostTime = DateTime.Now,
            User = await _userRepository.GetUserById(request.UserId),
            Psychologist = await _psychoRepository.GetPsychologistById(request.PsychologistId),
        };

        await _reviewRepository.CreateReview(review);
    }

    public async Task UpdateReview(Guid reviewId, UpdateReviewRequest request)
    {
        var review = await _reviewRepository.GetReviewById(reviewId);
        if (review == null)
        {
            throw new Exception("Review not found");
        }

        review.Rate = request.NewRate;
        review.Description = request.NewDescrption;

        await _reviewRepository.UpdateReview(review);
    }

    public async Task DeleteReview(Guid reviewId)
    {
        var review = await _reviewRepository.GetReviewById(reviewId);
        if (review == null)
        {
            throw new Exception("Review not found");
        }

        await _reviewRepository.DeleteReview(reviewId);
    }

    public ICollection<PublicReviewInfoResponse> GetPsychologistReviews(Guid reviewId)
    {
        ICollection<PublicReviewInfoResponse> reviews = _reviewRepository.GetAllReviews(reviewId)
            .Select(r => new PublicReviewInfoResponse(r.User.Id, r.Psychologist.Id, r.Rate, r.Description, r.PostTime))
            .ToList();
        return reviews;
    }
}