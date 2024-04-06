using MediatR;
using MentallHealthSupport.Application.Models.Dto.Spot;

namespace MentallHealthSupport.Application.Events.Queries.Spot;

public class GetPsychologistFreeSpotsQuery : IRequest<ICollection<PublicSpotInfoResponse>>
{
    public Guid PsychologistId { get; }

    public GetPsychologistFreeSpotsQuery(Guid psychologistId)
    {
        PsychologistId = psychologistId;
    }
}