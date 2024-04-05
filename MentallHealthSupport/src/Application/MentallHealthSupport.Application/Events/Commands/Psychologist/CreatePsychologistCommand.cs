using MediatR;
using MentallHealthSupport.Application.Models.Dto.Psychologist;

namespace MentallHealthSupport.Application.Events.Commands.User;

public class CreatePsychologistCommand : IRequest<Guid>
{
    public RegistratePsychologistRequest RegistratePsychologistRequest { get; set; }

    public CreatePsychologistCommand(RegistratePsychologistRequest registratePsychologistRequest)
    {
        RegistratePsychologistRequest = registratePsychologistRequest;
    }
}