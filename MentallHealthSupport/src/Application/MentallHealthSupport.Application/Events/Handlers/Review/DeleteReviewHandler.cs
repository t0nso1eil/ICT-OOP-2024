using MediatR;
using MentallHealthSupport.Application.Abstractions.Persistence.Repositories;
using MentallHealthSupport.Application.Events.Commands.Review;

namespace MentallHealthSupport.Application.Events.Handlers.Review;

public class DeleteReviewHandler : IRequestHandler<DeleteReviewCommand>
{
    private readonly IReviewRepository _reviewRepository;

    public DeleteReviewHandler(IReviewRepository reviewRepository)
    {
        _reviewRepository = reviewRepository;
    }

    public async Task Handle(DeleteReviewCommand request, CancellationToken cancellationToken)
    {
        await _reviewRepository.DeleteReview(request.ReviewId);
    }
}