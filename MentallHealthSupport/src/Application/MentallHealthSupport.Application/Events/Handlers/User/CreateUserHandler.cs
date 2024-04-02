#pragma warning disable CA1307

using MediatR;
using MentallHealthSupport.Application.Abstractions.Persistence.Repositories;
using MentallHealthSupport.Application.Events.Commands.User;
using MentallHealthSupport.Application.Exceptions;
using MentallHealthSupport.Application.Models.Dto.User;

namespace MentallHealthSupport.Application.Events.Handlers.User;

public class CreateUserHandler : IRequestHandler<CreateUserCommand, Guid>
{
    private readonly IUserRepository _userRepository;

    public CreateUserHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<Guid> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var existingUser = await _userRepository.GetUserByEmail(request.RegistrateUserRequest.Email);
        if (existingUser != null)
        {
            throw new ConflictException("User with this email already exists.");
        }

        CheckCorrectRegistrationInfo(request.RegistrateUserRequest);

        var user = request.RegistrateUserRequest.CreateUser();
        return await _userRepository.CreateUser(user);
    }

    private void CheckCorrectRegistrationInfo(RegistrateUserRequest request)
    {
        if (!request.FirstName.All(char.IsLetter) || !request.LastName.All(char.IsLetter))
        {
            throw new IncorrectInputException("Incorrect fullname.");
        }

        if (request.Sex is not ("m" or "f"))
        {
            throw new IncorrectInputException("Incorrect gender.");
        }

        if (!(request.Email.Contains("@email.ru") || request.Email.Contains("@yandex.ru") ||
              request.Email.Contains("@gmail.com")))
        {
            throw new IncorrectInputException("Incorrect email.");
        }
    }
}