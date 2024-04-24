using MediatR;
using MentallHealthSupport.Application.Models.Dto.User;

namespace MentallHealthSupport.Application.Events.Commands.User;

public class CreateUserCommand : IRequest<Guid>
{
    public RegistrateUserRequest RegistrateUserRequest { get; set; }

    public CreateUserCommand(RegistrateUserRequest registrateUserRequest)
    {
        RegistrateUserRequest = registrateUserRequest;
    }
}