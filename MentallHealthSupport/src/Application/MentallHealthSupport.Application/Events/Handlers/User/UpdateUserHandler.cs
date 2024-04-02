using MediatR;
using MentallHealthSupport.Application.Abstractions.Persistence.Repositories;
using MentallHealthSupport.Application.Events.Commands.User;
using MentallHealthSupport.Application.Exceptions;
using MentallHealthSupport.Application.Models.Dto.User;

namespace MentallHealthSupport.Application.Events.Handlers.User;

public class UpdateUserHandler : IRequestHandler<UpdateUserCommand, PublicUserInfoResponse>
{
    private readonly IUserRepository _userRepository;

    public UpdateUserHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<PublicUserInfoResponse> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetUserById(request.UserId);
        if (user == null)
        {
            throw new NotFoundException($"User with id {request.UserId} not found.");
        }

        user.FirstName = request.UpdateUserRequest.FirstName ?? user.FirstName;
        user.LastName = request.UpdateUserRequest.LastName ?? user.LastName;
        user.PhoneNumber = request.UpdateUserRequest.PhoneNumber ?? user.PhoneNumber;
        user.PasswordHash = request.UpdateUserRequest.Password ?? user.PasswordHash;
        user.AdditionalInfo = request.UpdateUserRequest.AdditionalInfo ?? user.AdditionalInfo;

        await _userRepository.UpdateUser(user);

        return PublicUserInfoResponse.FromUser(user);
    }
}