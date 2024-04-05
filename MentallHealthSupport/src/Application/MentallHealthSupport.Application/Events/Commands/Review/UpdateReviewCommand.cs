using MediatR;
using MentallHealthSupport.Application.Models.Dto.Review;


namespace MentallHealthSupport.Application.Events.Commands.Review
{
    public class UpdateReviewCommand : IRequest<PublicReviewInfoResponse>
    {
        public Guid UserId { get; }
        public uint? Rate { get; }
        public string? Description { get; }

        public UpdateReviewCommand(Guid userId, uint? rate, string? description)
        {
            UserId = userId;
            Rate = rate;
            Description = description;
        }
        
    }
}