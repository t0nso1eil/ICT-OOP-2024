using MediatR;
using MentallHealthSupport.Application.Models.Dto.Spot;

namespace MentallHealthSupport.Application.Events.Queries.Spot;

public class GetPsychologistScheduleQuery : IRequest<ICollection<PublicSpotInfoResponse>>
{
    public Guid PsychologistId { get; }

    public GetPsychologistScheduleQuery(Guid psychologistId)
    {
        PsychologistId = psychologistId;
    }
}