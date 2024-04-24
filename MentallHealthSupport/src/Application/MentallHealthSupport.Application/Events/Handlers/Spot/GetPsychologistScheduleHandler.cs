using MediatR;
using MentallHealthSupport.Application.Abstractions.Persistence.Repositories;
using MentallHealthSupport.Application.Events.Queries.Spot;
using MentallHealthSupport.Application.Models.Dto.Spot;

namespace MentallHealthSupport.Application.Events.Handlers.Spot;

public class GetPsychologistScheduleHandler : IRequestHandler<GetPsychologistScheduleQuery, ICollection<PublicSpotInfoResponse>>
{
    private readonly ISpotRepository _spotRepository;

    public GetPsychologistScheduleHandler(ISpotRepository spotRepository)
    {
        _spotRepository = spotRepository;
    }

    public async Task<ICollection<PublicSpotInfoResponse>> Handle(GetPsychologistScheduleQuery request, CancellationToken cancellationToken)
    {
        var schedule = await _spotRepository.GetPsychologistSchedule(request.PsychologistId);
        return schedule.Select(spot => PublicSpotInfoResponse.FromSpot(spot)).ToList();
    }
}