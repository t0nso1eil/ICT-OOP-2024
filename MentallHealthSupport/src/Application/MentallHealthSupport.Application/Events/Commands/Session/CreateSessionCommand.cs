using MediatR;
using MentallHealthSupport.Application.Models.Dto.Session;

namespace MentallHealthSupport.Application.Events.Commands.Session;

public class CreateSessionCommand : IRequest<Guid>
{
    public CreateSessionRequest CreateSessionRequest { get; }

    public CreateSessionCommand(CreateSessionRequest createSessionRequest)
    {
        CreateSessionRequest = createSessionRequest;
    }
}