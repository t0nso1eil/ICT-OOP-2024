using MentallHealthSupport.Application.Abstractions.Persistence.Repositories;
using MentallHealthSupport.Application.Events.Commands.Review;
using MentallHealthSupport.Application.Exceptions;
using MentallHealthSupport.Application.Models.Dto.Review;


namespace MentallHealthSupport.Application.Events.Handlers.Review;

public class UpdateReviewHandler
{
    private readonly IReviewRepository _reviewRepository;

    public UpdateReviewHandler(IReviewRepository reviewRepository)
    {
        _reviewRepository = reviewRepository;
    }

    public async Task<PublicReviewInfoResponse> Handle(
        UpdateReviewCommand request,
        CancellationToken cancellationToken)
    {
        var review = await _reviewRepository.GetReviewById(request.UserId);

        if (review == null)
        {
            throw new NotFoundException($"Review with ID not found.");
        }

        if (request.Rate != null)
        {
            review.Rate = request.Rate.Value;
        }

        if (request.Description != null)
        {
            review.Description = request.Description;
        }

        await _reviewRepository.UpdateReview(review);

        return PublicReviewInfoResponse.FromReview(review);
    }
}