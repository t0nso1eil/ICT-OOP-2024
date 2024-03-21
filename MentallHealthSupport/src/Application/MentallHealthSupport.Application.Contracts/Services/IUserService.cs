using MentallHealthSupport.Application.Models.Dto.User;
using MentallHealthSupport.Application.Models.Entities;

namespace MentallHealthSupport.Application.Contracts.Services;
public interface IUserService
{
    public Task<Guid> CreateUser(RegistrateUserRequest registrateUserRequest);

    public Task<PublicUserInfoResponse> GetUser(Guid userId);

    public Task UpdateUser(Guid id, UpdateUserRequest updateUserRequest);

    public Task<string> Login(LoginRequest loginRequest);

    User CreateUserEntity(RegistrateUserRequest request);
}