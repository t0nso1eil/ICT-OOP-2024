using MediatR;
using MentallHealthSupport.Application.Models.Dto;

namespace MentallHealthSupport.Application.Events.Queries.Session;

public class GetUserSessionsQuery : IRequest<ICollection<SessionInfo>>
{
    public Guid UserId { get; }

    public GetUserSessionsQuery(Guid userId)
    {
        UserId = userId;
    }
}