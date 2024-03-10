namespace MentallHealthSupport.Application.Services;

using MentallHealthSupport.Application.Abstractions.Persistence.Repositories;
using MentallHealthSupport.Application.Contracts.Services;
using MentallHealthSupport.Application.Models.Dto;
using MentallHealthSupport.Application.Models.Entities;
using static System.DateTime;

public class UserService(IUserRepository userRepository) : IUserService
{
    private readonly IUserRepository _userRepository = userRepository;

    public async Task CreateUser(RegistrateUserDto registrateUserDto, CancellationToken cancellationToken)
    {
        var existingUser = await _userRepository.GetUserByEmail(registrateUserDto.Email, cancellationToken);
        if (existingUser != null)
        {
            throw new Exception("такой уже есть");
        }

        var user = new User
        {
            Id = registrateUserDto.Id,
            FirstName = registrateUserDto.FirstName,
            LastName = registrateUserDto.LastName,
            Email = registrateUserDto.Email,
            PhoneNumber = registrateUserDto.PhoneNumber,
            PasswordHash = registrateUserDto.PasswordHash,
            Birthday = registrateUserDto.Birthday,
            Age = CalculateAge(registrateUserDto.Birthday),
            Sex = registrateUserDto.Sex,
            AdditionalInfo = registrateUserDto.AdditionalInfo,
            RegistrationDate = Now,
        };
        await _userRepository.CreateUser(user, cancellationToken);
    }

    public async Task<UserPublicInfo> GetUser(Guid userId, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetUserById(userId, cancellationToken);
        return new UserPublicInfo(user.FirstName, user.LastName, user.Email, user.PhoneNumber, user.Birthday, user.Age, user.AdditionalInfo, user.RegistrationDate);
    }

    public async Task UpdateUser(Guid id, UpdateUserDto updateUserDto, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetUserById(id, cancellationToken);
        user.FirstName = updateUserDto.FirstName ?? user.FirstName;
        user.LastName = updateUserDto.LastName ?? user.LastName;
        user.PhoneNumber = updateUserDto.PhoneNumber ?? user.PhoneNumber;
        user.PasswordHash = updateUserDto.Password ?? user.PasswordHash;
        user.AdditionalInfo = updateUserDto.AdditionalInfo ?? user.AdditionalInfo;
        await _userRepository.UpdateUser(user, cancellationToken);
    }

    public Task Login(LoginDto loginDto)
    {
        throw new NotImplementedException();
    }

    private static uint CalculateAge(DateOnly birthday)
    {
        var today = Today;

        // переписать
        var age = (uint)(today.Year - birthday.Year);

        return age;
    }
}