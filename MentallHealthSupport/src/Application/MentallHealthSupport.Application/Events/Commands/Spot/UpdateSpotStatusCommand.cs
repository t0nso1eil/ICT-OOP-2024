using MediatR;
using MentallHealthSupport.Application.Models.Dto;

namespace MentallHealthSupport.Application.Events.Commands.Spot;

public class UpdateSpotStatusCommand : IRequest<UpdateSpotRequest>
{
    public Guid Id { get; }
    public string Status { get; }

    public UpdateSpotStatusCommand(Guid id, string status)
    {
        Id = id;
        Status = status;
    }
}