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
using static System.DateTime;

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

        var user = CreateUserEntity(registrateUserRequest);
        await _userRepository.CreateUser(user);
        return user.Id;
    }

    public async Task<PublicUserInfoResponse> GetUser(Guid userId)
    {
        var user = await _userRepository.GetUserById(userId);
        return CreateUserInfoResponse(user);
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
        return CreateUserInfoResponse(user);
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
            throw new Exception("неправильный пароль");
        }

        return _jwtProvider.GenerateToken(user.Id);
    }

    public User CreateUserEntity(RegistrateUserRequest request)
    {
        CheckCorrectRegistrationInfo(request);

        var user = new User
        {
            Id = Guid.NewGuid(),
            FirstName = request.FirstName,
            LastName = request.LastName,
            Email = request.Email,
            PhoneNumber = request.PhoneNumber,
            PasswordHash = _passwordHasher.GenerateHash(request.Password),
            Birthday = request.Birthday,
            Age = (uint)CalculateAge(request.Birthday),
            Sex = request.Sex,
            AdditionalInfo = request.AdditionalInfo,
            RegistrationDate = Now,
        };
        return user;
    }

    private PublicUserInfoResponse CreateUserInfoResponse(User user)
    {
        return new PublicUserInfoResponse(
            user.FirstName,
            user.LastName,
            user.Email,
            user.PhoneNumber,
            user.Birthday,
            user.Age,
            user.AdditionalInfo,
            user.RegistrationDate);
    }

    private int CalculateAge(DateOnly birthday)
    {
        DateTime dateTime = DateTime.Now;
        DateOnly currentDate = new DateOnly(dateTime.Year, dateTime.Month, dateTime.Day);
        int age = currentDate.Year - birthday.Year;
        if (currentDate.DayOfYear < birthday.DayOfYear)
        {
            age--;
        }

        return age;
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