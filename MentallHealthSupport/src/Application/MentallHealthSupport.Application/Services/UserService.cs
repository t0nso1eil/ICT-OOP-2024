#pragma warning disable IDE0051
#pragma warning disable CA1307
#pragma warning disable IDE0008
#pragma warning restore SA1204
#pragma warning disable IDE0007
#pragma warning disable IDE0005

using MentallHealthSupport.Application.Abstractions.Persistence.Repositories;
using MentallHealthSupport.Application.Contracts.Services;
using MentallHealthSupport.Application.Exceptions;
using MentallHealthSupport.Application.Models.Dto.User;
using MentallHealthSupport.Application.Models.Entities;
using MentallHealthSupport.Application.Services.Auth;
using Microsoft.Extensions.Options;

namespace MentallHealthSupport.Application.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly PasswordHasher _passwordHasher;
    private readonly JwtProvider _jwtProvider;

    public UserService(IUserRepository userRepository, IOptions<JwtOption> options)
    {
        _userRepository = userRepository;
        _passwordHasher = new PasswordHasher();
        _jwtProvider = new JwtProvider(options);
    }

    public async Task<Guid> CreateUser(RegistrateUserRequest registrateUserRequest)
    {
        var existingUser = await _userRepository.GetUserByEmail(registrateUserRequest.Email);
        if (existingUser != null)
        {
            throw new ConflictException("User with this email already exists.");
        }

        CheckCorrectRegistrationInfo(registrateUserRequest);
        var user = registrateUserRequest.CreateUser();
        await _userRepository.CreateUser(user);
        var userFromDB = await _userRepository.GetUserByEmail(user.Email);
        return userFromDB!.Id;
    }

    public async Task<PublicUserInfoResponse> GetUser(Guid userId)
    {
        var user = await _userRepository.GetUserById(userId);
        return PublicUserInfoResponse.FromUser(user);
    }

    public async Task<PublicUserInfoResponse> UpdateUser(Guid id, UpdateUserRequest updateUserRequest)
    {
        var user = await _userRepository.GetUserById(id);
        user.FirstName = updateUserRequest.FirstName ?? user.FirstName;
        user.LastName = updateUserRequest.LastName ?? user.LastName;
        user.PhoneNumber = updateUserRequest.PhoneNumber ?? user.PhoneNumber;
        user.PasswordHash = updateUserRequest.Password ?? user.PasswordHash;
        user.AdditionalInfo = updateUserRequest.AdditionalInfo ?? user.AdditionalInfo;
        await _userRepository.UpdateUser(user);
        return PublicUserInfoResponse.FromUser(user);
    }

    public async Task<string> Login(LoginRequest loginRequest)
    {
        var user = await _userRepository.GetUserByEmail(loginRequest.Email);
        if (user is null)
        {
            throw new NotFoundException("This user doesn't exist.");
        }

        var result = _passwordHasher.Verify(loginRequest.Password, user.PasswordHash);
        if (result == false)
        {
            throw new IncorrectInputException("Incorrect password");
        }

        return _jwtProvider.GenerateToken(user.Id);
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