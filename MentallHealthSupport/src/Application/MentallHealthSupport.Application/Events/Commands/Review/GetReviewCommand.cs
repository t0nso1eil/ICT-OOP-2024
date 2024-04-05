namespace MentallHealthSupport.Application.Events.Commands.Review;


public class GetReviewCommand
{
    public Guid ReviewId { get; }

    public GetReviewCommand(Guid reviewId)
    {
        ReviewId = reviewId;
    }
}