namespace MentallHealthSupport.Infrastructure.Persistence.Repositories;

using MentallHealthSupport.Application.Abstractions.Persistence.Repositories;
using MentallHealthSupport.Application.Models.Entities;
using MentallHealthSupport.Infrastructure.Persistence.Contexts;
using MentallHealthSupport.Infrastructure.Persistence.Mapping;
using MentallHealthSupport.Infrastructure.Persistence.Models;
using Microsoft.EntityFrameworkCore;

public class UserRepository(ApplicationDbContext dbContext) : IUserRepository
{
    public async Task CreateUser(User user, CancellationToken cancellationToken)
    {
        var userModel = MapToModel(user);
        await dbContext.AddAsync(userModel, cancellationToken);
        await dbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task<User> GetUserById(Guid id, CancellationToken cancellationToken)
    {
        var userModel = await dbContext.Users.FirstOrDefaultAsync(user => user.Id == id, cancellationToken: cancellationToken);
        if (userModel == null)
        {
            throw new Exception("такого нет");
        }

        return MapToEntity(userModel);
    }

    public async Task UpdateUser(User newUser, CancellationToken cancellationToken)
    {
        var newUserModel = MapToModel(newUser);
        var currUser = await dbContext.Users.FindAsync(newUserModel.Id);
        dbContext.Entry(currUser!).CurrentValues.SetValues(newUserModel);
        await dbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task<User?> GetUserByEmail(string email, CancellationToken cancellationToken)
    {
        var userModel = await dbContext.Users.FirstOrDefaultAsync(user => user.Email == email, cancellationToken: cancellationToken);
        return userModel == null ? null : MapToEntity(userModel);
    }

    private User MapToEntity(UserModel model)
    {
        return UserMapper.ToEntity(model);
    }

    private UserModel MapToModel(User entity)
    {
        return UserMapper.ToModel(entity);
    }
}