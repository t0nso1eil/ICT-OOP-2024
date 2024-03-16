using System.Collections;
using MentallHealthSupport.Application.Abstractions.Persistence.Repositories;
using MentallHealthSupport.Application.Contracts;
using MentallHealthSupport.Application.Models.Dto;
using MentallHealthSupport.Application.Models.Entities;

namespace MentallHealthSupport.Application.Services;

public class ReviewService : IReviewService
{
    private readonly IReviewRepository _reviewRepository;
    //private readonly IUserRepository _userRepository;
    //private readonly IPsychologist _psychoRepository;

    public ReviewService(IReviewRepository reviewRepository)
    {
        _reviewRepository = reviewRepository;
    }

    public async Task CreateReview(CreateReviewRequest createReviewRequest)
    {
        var review = new Review
        {
            Id = Guid.NewGuid(),
            Description = createReviewRequest.Description,
            Rate = createReviewRequest.Rate,
            PostTime = DateTime.Now,
            //User = _userRepository.GetById(createReviewRequest.UserId),
            //Psychologist = _psychoRepository.BetById(createReviewRequest.PsychologistId)
        };

        await _reviewRepository.CreateReview(review);
    }


    public async Task UpdateReview(Guid reviewId, UpdateReviewRequest updateReviewRequest)
    {
        var review = await _reviewRepository.GetReviewById(reviewId);
        if (review == null)
        {
            throw new Exception("Review not found");
        }

        review.Rate = updateReviewRequest.NewRate;
        review.Description = updateReviewRequest.NewDescrption;

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
        ICollection<PublicReviewInfoResponse> reviews = _reviewRepository.GetAllReviews(reviewId).Select(r => new PublicReviewInfoResponse(r.User.Id, r.Psychologist.Id, r.Rate, r.Description, r.PostTime)).ToList();
        return reviews;
    }
}