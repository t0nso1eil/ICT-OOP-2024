using MediatR;
using MentallHealthSupport.Application.Models.Dto;

namespace MentallHealthSupport.Application.Events.Commands.Session;

public class CreateSessionCommand : IRequest<Guid>
{
    public CreateSessionRequest CreateSessionRequest { get; }

    public CreateSessionCommand(CreateSessionRequest createSessionRequest)
    {
        CreateSessionRequest = createSessionRequest;
    }
}