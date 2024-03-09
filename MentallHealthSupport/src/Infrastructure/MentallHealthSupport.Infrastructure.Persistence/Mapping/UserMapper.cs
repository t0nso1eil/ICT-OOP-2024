namespace MentallHealthSupport.Infrastructure.Persistence.Mapping;

using MentallHealthSupport.Application.Models.Entities;
using MentallHealthSupport.Infrastructure.Persistence.Models;

public class UserMapper
{
    public static User ToEntity(UserModel userModel)
    {
        // дописать мэппинг связей
        return new User
        {
            Id = userModel.Id,
            FirstName = userModel.FirstName,
            LastName = userModel.LastName,
            Email = userModel.Email,
            PhoneNumber = userModel.PhoneNumber,
            Password = userModel.Password,
            Birthday = userModel.Birthday,
            Age = userModel.Age,
            Sex = userModel.Sex,
            AdditionalInfo = userModel.AdditionalInfo,
            RegistrationDate = userModel.RegistrationDate,
        };
    }

    public static UserModel ToModel(User user)
    {
        // дописать мэппинг связей
        return new UserModel
        {
            Id = user.Id,
            FirstName = user.FirstName,
            LastName = user.LastName,
            Email = user.Email,
            PhoneNumber = user.PhoneNumber,
            Password = user.Password,
            Birthday = user.Birthday,
            Age = user.Age,
            Sex = user.Sex,
            AdditionalInfo = user.AdditionalInfo,
            RegistrationDate = user.RegistrationDate,
        };
    }
}