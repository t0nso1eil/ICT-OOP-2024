using MediatR;
using MentallHealthSupport.Application.Abstractions.Persistence.Repositories;
using MentallHealthSupport.Application.Events.Queries.Review;
using MentallHealthSupport.Application.Models.Dto.Review;

namespace MentallHealthSupport.Application.Events.Handlers.Review;

public class GetPsychologistReviewsHandler : IRequestHandler<GetPsychologistReviewsQuery, ICollection<PublicReviewInfoResponse>>
{
    private readonly IReviewRepository _reviewRepository;

    public GetPsychologistReviewsHandler(IReviewRepository reviewRepository)
    {
        _reviewRepository = reviewRepository;
    }

    public async Task<ICollection<PublicReviewInfoResponse>> Handle(GetPsychologistReviewsQuery request, CancellationToken cancellationToken)
    {
        var reviews = await _reviewRepository.GetAllReviews(request.PsychologistId);
        return reviews.Select(review => PublicReviewInfoResponse.FromReview(review)).ToList();
    }
}