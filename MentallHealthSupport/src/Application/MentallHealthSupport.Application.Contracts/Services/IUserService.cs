namespace MentallHealthSupport.Application.Contracts.Services;

using MentallHealthSupport.Application.Models.Dto;
using MentallHealthSupport.Application.Models.Entities;

public interface IUserService
{
    public Task CreateUser(RegistrateUserDto registrateUserDto, CancellationToken cancellationToken);

    public Task<UserPublicInfo> GetUser(Guid userId, CancellationToken cancellationToken);

    public void UpdateUser(Guid id, UpdateUserDto updateUserDto, CancellationToken cancellationToken);
}