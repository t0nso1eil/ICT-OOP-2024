using MentallHealthSupport.Application.Models.Entities;
using MentallHealthSupport.Infrastructure.Persistence.Models;

namespace MentallHealthSupport.Infrastructure.Persistence.Mapping;
public class UserMapper
{
    public static User ToEntity(UserModel userModel)
    {
        var user = new User
        {
            Id = userModel.Id,
            FirstName = userModel.FirstName,
            LastName = userModel.LastName,
            Email = userModel.Email,
            PhoneNumber = userModel.PhoneNumber,
            PasswordHash = userModel.PasswordHash,
            Birthday = userModel.Birthday,
            Age = userModel.Age,
            Sex = userModel.Sex,
            AdditionalInfo = userModel.AdditionalInfo,
            RegistrationDate = userModel.RegistrationDate,
            IsPsychologist = userModel.IsPsychologist,
        };
        return user;
    }

    public static UserModel ToModel(User user)
    {
        var userModel = new UserModel
        {
            Id = user.Id,
            FirstName = user.FirstName,
            LastName = user.LastName,
            Email = user.Email,
            PhoneNumber = user.PhoneNumber,
            PasswordHash = user.PasswordHash,
            Birthday = user.Birthday,
            Age = user.Age,
            Sex = user.Sex,
            AdditionalInfo = user.AdditionalInfo,
            RegistrationDate = user.RegistrationDate,
            IsPsychologist = user.IsPsychologist,
        };
        return userModel;
    }
}