using MediatR;
using MentallHealthSupport.Application.Models.Dto.User;

namespace MentallHealthSupport.Application.Events.Commands.User;

public class UpdateUserCommand : IRequest<PublicUserInfoResponse>
{
    public Guid UserId { get; }

    public UpdateUserRequest UpdateUserRequest { get; }

    public UpdateUserCommand(Guid userId, UpdateUserRequest updateUserRequest)
    {
        UserId = userId;
        UpdateUserRequest = updateUserRequest;
    }
}