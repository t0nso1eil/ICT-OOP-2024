using MediatR;
using MentallHealthSupport.Application.Models.Dto.Psychologist;

namespace MentallHealthSupport.Application.Events.Queries.Psychologist;

public class GetPsychologistsByPriceQuery : IRequest<ICollection<PublicPsychologistInfoResponse>>
{
    public decimal PriceMin { get; }

    public decimal PriceMax { get; }

    public GetPsychologistsByPriceQuery(decimal priceMin, decimal priceMax)
    {
        PriceMin = priceMin;
        PriceMax = priceMax;
    }
}