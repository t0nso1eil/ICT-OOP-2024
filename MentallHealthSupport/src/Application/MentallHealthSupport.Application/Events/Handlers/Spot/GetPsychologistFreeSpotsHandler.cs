using MediatR;
using MentallHealthSupport.Application.Abstractions.Persistence.Repositories;
using MentallHealthSupport.Application.Events.Queries.Spot;
using MentallHealthSupport.Application.Models.Dto.Spot;

namespace MentallHealthSupport.Application.Events.Handlers.Spot;

public class GetPsychologistFreeSpotsHandler : IRequestHandler<GetPsychologistFreeSpotsQuery, ICollection<PublicSpotInfoResponse>>
{
    private readonly ISpotRepository _spotRepository;

    public GetPsychologistFreeSpotsHandler(ISpotRepository spotRepository)
    {
        _spotRepository = spotRepository;
    }

    public async Task<ICollection<PublicSpotInfoResponse>> Handle(GetPsychologistFreeSpotsQuery request, CancellationToken cancellationToken)
    {
        var availableSpots = await _spotRepository.GetPsychologistFreeSpotsById(request.PsychologistId);
        return availableSpots.Select(spot => PublicSpotInfoResponse.FromSpot(spot)).ToList();
    }
}