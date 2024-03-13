using MentallHealthSupport.Application.Models.Entities;

namespace MentallHealthSupport.Application.Abstractions.Persistence.Repositories;
public interface IUserRepository
{
    Task CreateUser(User user);

    Task<User> GetUserById(Guid id);

    Task UpdateUser(User newUser);

    Task<User?> GetUserByEmail(string email);
}