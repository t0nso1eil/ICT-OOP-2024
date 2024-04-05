using MediatR;
using MentallHealthSupport.Application.Models.Dto;

namespace MentallHealthSupport.Application.Events.Queries.Spot
{
    public class GetSpotQuery : IRequest<SpotInfo>
    {
        public Guid SpotId { get; }

        public GetSpotQuery(Guid spotId)
        {
            SpotId = spotId;
        }
    }
}