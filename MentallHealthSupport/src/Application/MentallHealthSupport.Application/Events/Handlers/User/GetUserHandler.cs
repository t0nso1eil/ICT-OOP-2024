using MediatR;
using MentallHealthSupport.Application.Abstractions.Persistence.Repositories;
using MentallHealthSupport.Application.Events.Queries.User;
using MentallHealthSupport.Application.Models.Dto.User;

namespace MentallHealthSupport.Application.Events.Handlers.User;

public class GetUserHandler : IRequestHandler<GetUserQuery, PublicUserInfoResponse>
{
    private readonly IUserRepository _userRepository;

    public GetUserHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<PublicUserInfoResponse> Handle(GetUserQuery request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetUserById(request.UserId);
        return PublicUserInfoResponse.FromUser(user);
    }
}