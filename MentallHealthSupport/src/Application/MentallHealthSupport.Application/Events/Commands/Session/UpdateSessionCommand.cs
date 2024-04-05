using MediatR;
using MentallHealthSupport.Application.Models.Dto;

namespace MentallHealthSupport.Application.Events.Commands.Session;

public class UpdateSessionStatusCommand : IRequest<UpdateSessionRequest>
{
    public Guid Id { get; }
    public string Status { get; }

    public UpdateSessionStatusCommand(Guid id, string status)
    {
        Id = id;
        Status = status;
    }
}