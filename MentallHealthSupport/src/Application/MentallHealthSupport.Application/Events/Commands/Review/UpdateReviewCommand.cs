using MediatR;
using MentallHealthSupport.Application.Models.Dto.Review;

namespace MentallHealthSupport.Application.Events.Commands.Review
{
    public class UpdateReviewCommand : IRequest<PublicReviewInfoResponse>
    {
        public Guid ReviewId { get; }

        public UpdateReviewRequest UpdateReviewRequest { get; set; }

        public UpdateReviewCommand(Guid reviewId, UpdateReviewRequest updateReviewRequest)
        {
            ReviewId = reviewId;
            UpdateReviewRequest = updateReviewRequest;
        }
    }
}