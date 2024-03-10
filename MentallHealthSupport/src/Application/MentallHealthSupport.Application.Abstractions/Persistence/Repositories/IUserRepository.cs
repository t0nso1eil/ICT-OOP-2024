namespace MentallHealthSupport.Application.Abstractions.Persistence.Repositories;

using MentallHealthSupport.Application.Models.Entities;

public interface IUserRepository
{
    Task CreateUser(User user, CancellationToken cancellationToken);

    Task<User> GetUserById(Guid id, CancellationToken cancellationToken);

    Task UpdateUser(User newUser, CancellationToken cancellationToken);

    Task<User?> GetUserByEmail(string email, CancellationToken cancellationToken);
}