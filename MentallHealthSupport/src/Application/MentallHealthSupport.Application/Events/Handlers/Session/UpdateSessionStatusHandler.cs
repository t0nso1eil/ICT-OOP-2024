using MediatR;
using MentallHealthSupport.Application.Abstractions.Persistence.Repositories;
using MentallHealthSupport.Application.Events.Commands.Session;
using MentallHealthSupport.Application.Exceptions;
using MentallHealthSupport.Application.Models.Entities.Enums;

namespace MentallHealthSupport.Application.Events.Handlers.Session;

public class UpdateSessionStatusHandler : IRequestHandler<UpdateSessionStatusCommand, PublicSessionInfoResponse>
{
    private readonly ISessionRepository _sessionRepository;

    public UpdateSessionStatusHandler(ISessionRepository sessionRepository)
    {
        _sessionRepository = sessionRepository;
    }

    public async Task<PublicSessionInfoResponse> Handle(UpdateSessionStatusCommand request, CancellationToken cancellationToken)
    {
        var sessionToUpdate = await _sessionRepository.GetSessionById(request.Id);
        if (sessionToUpdate == null)
        {
            throw new NotFoundException("Session not found");
        }

        bool statusIsDefined = Enum.IsDefined(typeof(SessionStatuses), request.Status);
        if (statusIsDefined)
        {
            sessionToUpdate.Status = request.Status;
            await _sessionRepository.UpdateSessionStatus(sessionToUpdate);
        }
        else
        {
            throw new IncorrectInputException("Incorrect session status");
        }

        return PublicSessionInfoResponse.FromSession(sessionToUpdate);
    }
}