using MediatR;
using MentallHealthSupport.Application.Models.Dto.Psychologist;

namespace MentallHealthSupport.Application.Events.Commands.Psychologist;

public class UpdatePsychologistCommand : IRequest<PublicPsychologistInfoResponse>
{
    public Guid PsychologistId { get; }

    public UpdatePsychologistRequest UpdatePsychologistRequest { get; }

    public UpdatePsychologistCommand(Guid psychologistId, UpdatePsychologistRequest updatePsychologistRequest)
    {
        PsychologistId = psychologistId;
        UpdatePsychologistRequest = updatePsychologistRequest;
    }
}