using MediatR;
using MentallHealthSupport.Application.Abstractions.Persistence.Repositories;
using MentallHealthSupport.Application.Events.Queries.Psychologist;
using MentallHealthSupport.Application.Models.Dto.Psychologist;

namespace MentallHealthSupport.Application.Events.Handlers.Psychologist;

public class GetPsychologistHandler : IRequestHandler<GetPsychologistQuery, PublicPsychologistInfoResponse>
{
    private readonly IPsychologistRepository _psychologistRepository;

    public GetPsychologistHandler(IPsychologistRepository psychologistRepository)
    {
        _psychologistRepository = psychologistRepository;
    }

    public async Task<PublicPsychologistInfoResponse> Handle(GetPsychologistQuery request, CancellationToken cancellationToken)
    {
        var psychologist = await _psychologistRepository.GetPsychologistById(request.PsychologistId);
        return PublicPsychologistInfoResponse.FromPsychologist(psychologist);
    }
}
