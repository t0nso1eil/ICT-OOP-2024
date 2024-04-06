using MediatR;
using MentallHealthSupport.Application.Abstractions.Persistence.Repositories;
using MentallHealthSupport.Application.Events.Commands.Session;
using MentallHealthSupport.Application.Exceptions;

namespace MentallHealthSupport.Application.Events.Handlers.Session;

public class CreateSessionHandler : IRequestHandler<CreateSessionCommand, Guid>
{
    private readonly ISpotRepository _spotRepository;
    private readonly IUserRepository _userRepository;
    private readonly ISessionRepository _sessionRepository;

    public CreateSessionHandler(ISpotRepository spotRepository, IUserRepository userRepository, ISessionRepository sessionRepository)
    {
        _spotRepository = spotRepository;
        _userRepository = userRepository;
        _sessionRepository = sessionRepository;
    }

    public async Task<Guid> Handle(CreateSessionCommand request, CancellationToken cancellationToken)
    {
        var createSessionRequest = request.CreateSessionRequest;

        var spot = await _spotRepository.GetSpotById(createSessionRequest.SpotId);
        if (spot == null)
        {
            throw new NotFoundException("Spot not found");
        }

        if (spot.Status == "Unavailable")
        {
            throw new ConflictException("Spot is unavailable");
        }

        var user = await _userRepository.GetUserById(createSessionRequest.UserId);
        if (user == null)
        {
            throw new NotFoundException("User not found");
        }

        var session = createSessionRequest.ToSession(user, spot);
        await _sessionRepository.CreateNewSession(session);

        return session.Id;
    }
}