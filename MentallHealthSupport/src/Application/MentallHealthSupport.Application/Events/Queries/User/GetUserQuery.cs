using MediatR;
using MentallHealthSupport.Application.Models.Dto.User;

namespace MentallHealthSupport.Application.Events.Queries.User;

public class GetUserQuery : IRequest<PublicUserInfoResponse>
{
    public Guid UserId { get; }

    public GetUserQuery(Guid userId)
    {
        UserId = userId;
    }
}