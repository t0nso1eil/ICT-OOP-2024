using MediatR;
using MentallHealthSupport.Application.Models.Dto.User;

namespace MentallHealthSupport.Application.Events.Commands.User;

public class LoginCommand : IRequest<string>
{
    public LoginRequest LoginRequest { get; }

    public LoginCommand(LoginRequest loginRequest)
    {
        LoginRequest = loginRequest;
    }
}