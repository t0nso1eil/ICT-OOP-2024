using MentallHealthSupport.Application.Models.Dto;

namespace MentallHealthSupport.Application.Contracts.Services;
public interface IUserService
{
    public Task<string> CreateUser(RegistrateUserRequest registrateUserRequest);

    public Task<PublicUserInfoResponse> GetUser(Guid userId);

    public Task UpdateUser(Guid id, UpdateUserRequest updateUserRequest);

    public Task<string> Login(LoginRequest loginRequest);
}