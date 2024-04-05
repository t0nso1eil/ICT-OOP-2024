using MediatR;
using MentallHealthSupport.Application.Models.Dto.Review;
using MentallHealthSupport.Application.Models.Dto.User;

namespace MentallHealthSupport.Application.Events.Commands.Review;

public class CreateReviewCommand : IRequest<Guid>
{
    public  CreateReviewRequest CreateReviewRequest { get; set; }

    public CreateReviewCommand(CreateReviewRequest createReviewRequest)
    {
        CreateReviewRequest = createReviewRequest;
    }
}