#pragma warning disable SA1028

using MediatR;
using MentallHealthSupport.Application.Models.Dto.Psychologist;

namespace MentallHealthSupport.Application.Events.Queries.Psychologist;

public class GetPsychologistsByRateQuery : IRequest<ICollection<PublicPsychologistInfoResponse>>
{
    public float RateMin { get; }

    public float RateMax { get; }
    
    public GetPsychologistsByRateQuery(float rateMin, float rateMax)
    {
        RateMin = rateMin;
        RateMax = rateMax;
    }
}