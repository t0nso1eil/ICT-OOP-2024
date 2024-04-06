using MediatR;
using MentallHealthSupport.Application.Models.Dto.Session;

namespace MentallHealthSupport.Application.Events.Queries.Session;

public class GetUserSessionsQuery : IRequest<ICollection<PublicSessionInfoResponse>>
{
    public Guid UserId { get; }

    public GetUserSessionsQuery(Guid userId)
    {
        UserId = userId;
    }
}