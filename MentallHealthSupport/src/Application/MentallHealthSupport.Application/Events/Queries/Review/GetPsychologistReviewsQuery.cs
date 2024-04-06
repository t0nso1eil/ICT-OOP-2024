using MediatR;
using MentallHealthSupport.Application.Models.Dto.Review;

namespace MentallHealthSupport.Application.Events.Queries.Review;

public class GetPsychologistReviewsQuery : IRequest<ICollection<PublicReviewInfoResponse>>
{
    public Guid PsychologistId { get; }

    public GetPsychologistReviewsQuery(Guid psychologistId)
    {
        PsychologistId = psychologistId;
    }
}