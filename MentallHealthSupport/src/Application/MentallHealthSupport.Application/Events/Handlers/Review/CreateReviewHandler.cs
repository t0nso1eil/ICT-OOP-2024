#pragma warning disable CA1307

using MediatR;
using MentallHealthSupport.Application.Abstractions.Persistence.Repositories;
using MentallHealthSupport.Application.Events.Commands.Review;
using MentallHealthSupport.Application.Exceptions;
using MentallHealthSupport.Application.Models.Dto.Review;
using MentallHealthSupport.Application.Models.Entities;


namespace MentallHealthSupport.Application.Events.Handlers.Review
{
    public class CreateReviewHandler : IRequestHandler<CreateReviewCommand, Guid>
    {
        private readonly IReviewRepository _reviewRepository;

        public CreateReviewHandler(IReviewRepository reviewRepository)
        {
            _reviewRepository = reviewRepository;
        }

        public async Task<Guid> Handle(CreateReviewCommand request, CancellationToken cancellationToken)
        {
            var existingReview = await _reviewRepository.GetReviewById(request.CreateReviewRequest.UserId);
            if (existingReview != null)
            {
                throw new ConflictException("Review from this user to this psychologist already exists.");
            }

            ValidateReviewRequest(request.CreateReviewRequest);
            
            var review = request.CreateReviewRequest.ToReview;
            return await _reviewRepository.CreateReview(review);
        }

        private void ValidateReviewRequest(CreateReviewRequest request)
        {
            if (request.Rate is < 1 or > 5)
            {
                throw new IncorrectInputException("Rate should be between 1 and 5.");
            }

            if (string.IsNullOrWhiteSpace(request.Description))
            {
                throw new IncorrectInputException("Description cannot be empty or whitespace.");
            }
        }
    }
}