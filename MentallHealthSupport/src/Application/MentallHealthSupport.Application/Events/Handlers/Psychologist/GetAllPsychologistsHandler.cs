#pragma warning disable IDE0008

using MediatR;
using MentallHealthSupport.Application.Abstractions.Persistence.Repositories;
using MentallHealthSupport.Application.Events.Queries.Psychologist;
using MentallHealthSupport.Application.Models.Dto.Psychologist;

namespace MentallHealthSupport.Application.Events.Handlers.Psychologist;

public class GetAllPsychologistsHandler : IRequestHandler<GetAllPsychologistsQuery, ICollection<PublicPsychologistInfoResponse>>
{
    private readonly IPsychologistRepository _psychologistRepository;

    public GetAllPsychologistsHandler(IPsychologistRepository psychologistRepository)
    {
        _psychologistRepository = psychologistRepository;
    }

    public async Task<ICollection<PublicPsychologistInfoResponse>> Handle(GetAllPsychologistsQuery request, CancellationToken cancellationToken)
    {
        var psychologists = await _psychologistRepository.GetAllPsychologists();
        return psychologists.Select(p => PublicPsychologistInfoResponse.FromPsychologist(p)).ToList();
    }
}
