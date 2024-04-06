using MediatR;
using MentallHealthSupport.Application.Models.Dto.Psychologist;

namespace MentallHealthSupport.Application.Events.Queries.Psychologist;

public class GetPsychologistQuery : IRequest<PublicPsychologistInfoResponse>
{
    public Guid PsychologistId { get; }

    public GetPsychologistQuery(Guid psychologistId)
    {
        PsychologistId = psychologistId;
    }
}