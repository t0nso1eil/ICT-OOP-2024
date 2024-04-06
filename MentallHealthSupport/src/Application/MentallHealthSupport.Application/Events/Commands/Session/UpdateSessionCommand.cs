using MediatR;
using MentallHealthSupport.Application.Models.Dto.Session;

namespace MentallHealthSupport.Application.Events.Commands.Session;

public class UpdateSessionCommand : IRequest<PublicSessionInfoResponse>
{
    public Guid Id { get; }

    public string Status { get; }

    public UpdateSessionCommand(Guid id, string status)
    {
        Id = id;
        Status = status;
    }
}