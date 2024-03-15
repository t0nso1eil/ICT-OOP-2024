﻿#pragma warning disable IDE0051
#pragma warning disable CA1307

using MentallHealthSupport.Application.Abstractions.Persistence.Repositories;
using MentallHealthSupport.Application.Contracts.Services;
using MentallHealthSupport.Application.Models.Dto;
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

    public async Task CreateUser(RegistrateUserRequest registrateUserRequest)
    {
        var existingUser = await _userRepository.GetUserByEmail(registrateUserRequest.Email);
        if (existingUser != null)
        {
            throw new Exception("такой уже есть");
        }

        CheckCorrectRegistrationInfo(registrateUserRequest);

        var user = new User
        {
            Id = Guid.NewGuid(),
            FirstName = registrateUserRequest.FirstName,
            LastName = registrateUserRequest.LastName,
            Email = registrateUserRequest.Email,
            PhoneNumber = registrateUserRequest.PhoneNumber,
            PasswordHash = _passwordHasher.GenerateHash(registrateUserRequest.Password),
            Birthday = registrateUserRequest.Birthday,
            Age = (uint)(Today.Year - registrateUserRequest.Birthday.Year),
            Sex = registrateUserRequest.Sex,
            AdditionalInfo = registrateUserRequest.AdditionalInfo,
            RegistrationDate = Now,
        };
        await _userRepository.CreateUser(user);
    }

    public async Task<PublicUserInfoResponse> GetUser(Guid userId)
    {
        var user = await _userRepository.GetUserById(userId);
        return new PublicUserInfoResponse(user.FirstName, user.LastName, user.Email, user.PhoneNumber, user.Birthday, user.Age, user.AdditionalInfo, user.RegistrationDate);
    }

    public async Task UpdateUser(Guid id, UpdateUserRequest updateUserRequest)
    {
        var user = await _userRepository.GetUserById(id);
        user.FirstName = updateUserRequest.FirstName ?? user.FirstName;
        user.LastName = updateUserRequest.LastName ?? user.LastName;
        user.PhoneNumber = updateUserRequest.PhoneNumber ?? user.PhoneNumber;
        user.PasswordHash = updateUserRequest.Password ?? user.PasswordHash;
        user.AdditionalInfo = updateUserRequest.AdditionalInfo ?? user.AdditionalInfo;
        await _userRepository.UpdateUser(user);
    }

    public async Task<string> Login(LoginRequest loginRequest)
    {
        var user = await _userRepository.GetUserByEmail(loginRequest.Email);
        if (user is null)
        {
            throw new Exception("такого нет");
        }

        var result = _passwordHasher.Verify(loginRequest.Password, user.PasswordHash);
        if (result == false)
        {
            throw new Exception("неправильный пароль");
        }

        return _jwtProvider.GenerateToken(user.Id);
    }

    private void CheckCorrectRegistrationInfo(RegistrateUserRequest request)
    {
        if (!request.FirstName.All(char.IsLetter) || !request.LastName.All(char.IsLetter))
        {
            throw new Exception("фио");
        }

        if (request.Sex is not ("male" or "female"))
        {
            throw new Exception("пол");
        }

        if (!request.Email.Contains("@mail.ru") || !request.Email.Contains("@gmail.com") || !request.Email.Contains("@yandex.com"))
        {
            throw new Exception("почта");
        }
    }
}