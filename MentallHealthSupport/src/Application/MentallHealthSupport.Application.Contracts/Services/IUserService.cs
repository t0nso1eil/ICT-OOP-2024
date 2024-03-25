using MentallHealthSupport.Application.Models.Dto.User;

namespace MentallHealthSupport.Application.Contracts.Services;
public interface IUserService
{
    public Task<Guid> CreateUser(RegistrateUserRequest registrateUserRequest);

    public Task<PublicUserInfoResponse> GetUser(Guid userId);

    public Task<PublicUserInfoResponse> UpdateUser(Guid id, UpdateUserRequest updateUserRequest);

    public Task<string> Login(LoginRequest loginRequest);
}