using MediatR;
using MentallHealthSupport.Application.Abstractions.Persistence.Repositories;
using MentallHealthSupport.Application.Events.Queries.Session;
using MentallHealthSupport.Application.Models.Dto;

namespace MentallHealthSupport.Application.Events.Handlers.Session;

public class GetUserSessionsHandler : IRequestHandler<GetUserSessionsQuery, ICollection<SessionInfo>>
{
    private readonly ISessionRepository _sessionRepository;

    public GetUserSessionsHandler(ISessionRepository sessionRepository)
    {
        _sessionRepository = sessionRepository;
    }

    public async Task<ICollection<SessionInfo>> Handle(GetUserSessionsQuery request, CancellationToken cancellationToken)
    {
        var sessions = await _sessionRepository.GetSessionsByUserId(request.UserId);
        return sessions.Select(session => PublicSessionInfoResponse.FromSession(session)).ToList();
    }
}