using MediatR;
using MentallHealthSupport.Application.Models.Dto.Review;


namespace MentallHealthSupport.Application.Events.Queries.Review
{
    public class GetReviewQuery : IRequest<PublicReviewInfoResponse>
    {
        public Guid ReviewId { get; }

        public GetReviewQuery(Guid reviewId)
        {
            ReviewId = reviewId;
        }
    }
}