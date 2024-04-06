using MediatR;
using MentallHealthSupport.Application.Models.Dto.Spot;

namespace MentallHealthSupport.Application.Events.Commands.Spot;

public class CreateSpotCommand : IRequest<Guid>
{
    public CreateSpotRequest CreateSpotRequest { get; set; }

    public CreateSpotCommand(CreateSpotRequest createSpotRequest)
    {
        CreateSpotRequest = createSpotRequest;
    }
}