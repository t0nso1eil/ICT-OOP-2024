using MediatR;
using MentallHealthSupport.Application.Abstractions.Persistence.Repositories;
using MentallHealthSupport.Application.Events.Commands.Spot;
using MentallHealthSupport.Application.Exceptions;

namespace MentallHealthSupport.Application.Events.Handlers.Spot;

public class CreateSpotHandler : IRequestHandler<CreateSpotCommand, Guid>
{
    private readonly IPsychologistRepository _psychologistRepository;
    private readonly ISpotRepository _spotRepository;

    public CreateSpotHandler(IPsychologistRepository psychologistRepository, ISpotRepository spotRepository)
    {
        _psychologistRepository = psychologistRepository;
        _spotRepository = spotRepository;
    }

    public async Task<Guid> Handle(CreateSpotCommand request, CancellationToken cancellationToken)
    {
        var createSpotRequest = request.CreateSpotRequest;

        if (createSpotRequest.Date < DateOnly.FromDateTime(DateTime.Now))
        {
            throw new IncorrectInputException("Incorrect data");
        }

        if (createSpotRequest.StartTime > createSpotRequest.EndTime)
        {
            throw new IncorrectInputException("Incorrect time");
        }

        var psychologist = await _psychologistRepository.GetPsychologistById(createSpotRequest.PsychologistId);
        if (psychologist == null)
        {
            throw new NotFoundException("Psychologist not found");
        }

        var spot = createSpotRequest.ToSpot(psychologist);

        var spots = await _spotRepository.GetPsychologistSchedule(createSpotRequest.PsychologistId);
        CheckCorrectTime(spots, spot);

        await _spotRepository.CreateSpot(spot);

        return spot.Id;
    }

    private void CheckCorrectTime(IEnumerable<Models.Entities.Spot> spots, Models.Entities.Spot newSpot)
    {
        foreach (var spot in spots)
        {
            if (newSpot.Date == spot.Date)
            {
                if ((newSpot.HourStart >= spot.HourStart && newSpot.HourStart < spot.HourEnd) ||
                    (newSpot.HourEnd > spot.HourStart && newSpot.HourEnd <= spot.HourEnd))
                {
                    throw new IncorrectInputException("Spot time conflicts with existing spots");
                }
            }
        }
}