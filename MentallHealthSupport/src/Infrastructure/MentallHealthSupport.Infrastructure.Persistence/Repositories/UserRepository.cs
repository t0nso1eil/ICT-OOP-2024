using MentallHealthSupport.Application.Abstractions.Persistence.Repositories;
using MentallHealthSupport.Application.Exceptions;
using MentallHealthSupport.Application.Models.Entities;
using MentallHealthSupport.Infrastructure.Persistence.Contexts;
using MentallHealthSupport.Infrastructure.Persistence.Mapping;
using MentallHealthSupport.Infrastructure.Persistence.Models;
using Microsoft.EntityFrameworkCore;

namespace MentallHealthSupport.Infrastructure.Persistence.Repositories;
public class UserRepository(ApplicationDbContext dbContext) : IUserRepository
{
    public async Task<Guid> CreateUser(User user)
    {
        var userModel = MapToModel(user);
        await dbContext.AddAsync(userModel);
        await dbContext.SaveChangesAsync();
        return userModel.Id;
    }

    public async Task<User> GetUserById(Guid id)
    {
        var userModel = await dbContext.Users.FirstOrDefaultAsync(user => user.Id == id);
        if (userModel == null)
        {
            throw new NotFoundException("Such user doesn't exist.");
        }

        return MapToEntity(userModel);
    }

    public async Task UpdateUser(User newUser)
    {
        var newUserModel = MapToModel(newUser);
        var currUser = await dbContext.Users.FindAsync(newUserModel.Id);
        dbContext.Entry(currUser!).CurrentValues.SetValues(newUserModel);
        await dbContext.SaveChangesAsync();
    }

    public async Task UpdateStatus(Guid userId, bool isPsychologist)
    {
        var user = await GetUserById(userId);
        user.IsPsychologist = isPsychologist;
        await UpdateUser(user);
    }

    public async Task<User?> GetUserByEmail(string email)
    {
        var userModel = await dbContext.Users.FirstOrDefaultAsync(user => user.Email == email);
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