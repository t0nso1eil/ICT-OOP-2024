using MediatR;

namespace MentallHealthSupport.Application.Events.Commands.Review
{
    public class DeleteReviewCommand : IRequest
    {
        public Guid ReviewId { get; }

        public DeleteReviewCommand(Guid reviewId)
        {
            ReviewId = reviewId;
        }
    }
}