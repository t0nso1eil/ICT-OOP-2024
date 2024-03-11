namespace MentallHealthSupport.Application.Contracts.Services;

using MentallHealthSupport.Application.Models.Dto;

public interface IUserService
{
    public Task CreateUser(RegistrateUserRequest registrateUserRequest);

    public Task<PublicUserInfoResponse> GetUser(Guid userId);

    public Task UpdateUser(Guid id, UpdateUserRequest updateUserRequest);

    public Task<string> Login(LoginRequest loginRequest);
}