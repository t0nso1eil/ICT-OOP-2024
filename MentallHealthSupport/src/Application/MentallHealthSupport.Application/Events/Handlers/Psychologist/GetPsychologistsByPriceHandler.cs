#pragma warning disable IDE0008

using MediatR;
using MentallHealthSupport.Application.Abstractions.Persistence.Repositories;
using MentallHealthSupport.Application.Events.Queries.Psychologist;
using MentallHealthSupport.Application.Models.Dto.Psychologist;

namespace MentallHealthSupport.Application.Events.Handlers.Psychologist;

public class GetPsychologistsByPriceHandler : IRequestHandler<GetPsychologistsByPriceQuery, ICollection<PublicPsychologistInfoResponse>>
{
    private readonly IPsychologistRepository _psychologistRepository;

    public GetPsychologistsByPriceHandler(IPsychologistRepository psychologistRepository)
    {
        _psychologistRepository = psychologistRepository;
    }

    public async Task<ICollection<PublicPsychologistInfoResponse>> Handle(GetPsychologistsByPriceQuery request, CancellationToken cancellationToken)
    {
        var psychologists = await _psychologistRepository.GetPsychologistsByPrice(request.PriceMin, request.PriceMax);
        return psychologists.Select(p => PublicPsychologistInfoResponse.FromPsychologist(p)).ToList();
    }
}
