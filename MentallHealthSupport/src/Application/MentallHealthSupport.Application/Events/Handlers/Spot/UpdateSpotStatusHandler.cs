using MediatR;
using MentallHealthSupport.Application.Abstractions.Persistence.Repositories;
using MentallHealthSupport.Application.Events.Commands.Spot;
using MentallHealthSupport.Application.Exceptions;
using MentallHealthSupport.Application.Models.Dto;
using MentallHealthSupport.Application.Models.Entities.Enums;

namespace MentallHealthSupport.Application.Events.Handlers.Spot;

public class UpdateSpotStatusHandler : IRequestHandler<UpdateSpotStatusCommand, SpotInfo>
{
    private readonly ISpotRepository _spotRepository;

    public UpdateSpotStatusHandler(ISpotRepository spotRepository)
    {
        _spotRepository = spotRepository;
    }

    public async Task<SpotInfo> Handle(UpdateSpotStatusCommand request, CancellationToken cancellationToken)
    {
        var spotToUpdate = await _spotRepository.GetSpotById(request.Id);
        if (spotToUpdate == null)
        {
            throw new NotFoundException("Spot not found");
        }

        bool spotIsDefined = Enum.IsDefined(typeof(SessionStatuses), request.Status);
        if (spotIsDefined)
        {
            spotToUpdate.Status = request.Status;
            await _spotRepository.UpdateSpotStatus(spotToUpdate);
        }
        else
        {
            throw new IncorrectInputException("Incorrect spot status");
        }

        return PublicSpotInfoResponse.FromSpot(spotToUpdate);
    }
}