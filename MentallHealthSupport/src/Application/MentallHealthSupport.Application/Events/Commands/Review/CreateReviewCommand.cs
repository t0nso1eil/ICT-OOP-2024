using MediatR;
using MentallHealthSupport.Application.Models.Dto.Review;

namespace MentallHealthSupport.Application.Events.Commands.Review
{
    public class CreateReviewCommand : IRequest<Guid>
    {
        public CreateReviewRequest CreateReviewRequest { get; set; }

        public CreateReviewCommand(CreateReviewRequest createReviewRequest)
        {
            CreateReviewRequest = createReviewRequest;
        }
    }
}