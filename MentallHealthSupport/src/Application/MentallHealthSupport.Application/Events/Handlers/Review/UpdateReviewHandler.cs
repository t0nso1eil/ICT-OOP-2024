using MediatR;
using MentallHealthSupport.Application.Abstractions.Persistence.Repositories;
using MentallHealthSupport.Application.Events.Commands.Review;
using MentallHealthSupport.Application.Models.Dto.Review;

namespace MentallHealthSupport.Application.Events.Handlers.Review;

public class UpdateReviewHandler : IRequestHandler<UpdateReviewCommand, PublicReviewInfoResponse>
{
    private readonly IReviewRepository _reviewRepository;

    public UpdateReviewHandler(IReviewRepository reviewRepository)
    {
        _reviewRepository = reviewRepository;
    }

    public async Task<PublicReviewInfoResponse> Handle(UpdateReviewCommand request, CancellationToken cancellationToken)
    {
        var updReview = request.UpdateReviewRequest;
        var review = await _reviewRepository.GetReviewById(request.ReviewId);
        review.Rate = updReview.Rate ?? review.Rate;
        review.Description = updReview.Description ?? review.Description;
        await _reviewRepository.UpdateReview(review);
        return PublicReviewInfoResponse.FromReview(review);
    }
}