using MediatR;
using MentallHealthSupport.Application.Models.Dto.Spot;

namespace MentallHealthSupport.Application.Events.Commands.Spot;

public class UpdateSpotStatusCommand : IRequest<PublicSpotInfoResponse>
{
    public Guid Id { get; }

    public string Status { get; }

    public UpdateSpotStatusCommand(Guid id, string status)
    {
        Id = id;
        Status = status;
    }
}