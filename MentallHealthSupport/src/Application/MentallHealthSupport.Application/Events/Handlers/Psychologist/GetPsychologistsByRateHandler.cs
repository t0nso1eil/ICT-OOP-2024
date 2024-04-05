#pragma warning disable IDE0008

using MediatR;
using MentallHealthSupport.Application.Abstractions.Persistence.Repositories;
using MentallHealthSupport.Application.Events.Queries.Psychologist;
using MentallHealthSupport.Application.Models.Dto.Psychologist;

namespace MentallHealthSupport.Application.Events.Handlers.Psychologist;

    public class GetPsychologistsByRateHandler : IRequestHandler<GetPsychologistsByRateQuery, ICollection<PublicPsychologistInfoResponse>>
    {
        private readonly IPsychologistRepository _psychologistRepository;

        public GetPsychologistsByRateHandler(IPsychologistRepository psychologistRepository)
        {
            _psychologistRepository = psychologistRepository;
        }

        public async Task<ICollection<PublicPsychologistInfoResponse>> Handle(GetPsychologistsByRateQuery request, CancellationToken cancellationToken)
        {
            var psychologists = await _psychologistRepository.GetPsychologistsByRate(request.RateMin, request.RateMax);
            return psychologists.Select(PublicPsychologistInfoResponse.FromPsychologist).ToList();
        }
    }
