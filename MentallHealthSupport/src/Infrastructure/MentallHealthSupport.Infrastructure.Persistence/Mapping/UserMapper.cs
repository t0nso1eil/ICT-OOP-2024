#pragma warning disable IDE0008
#pragma warning disable IDE0007

using MentallHealthSupport.Application.Models.Entities;
using MentallHealthSupport.Infrastructure.Persistence.Contexts;
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

        if (userModel.Psychologist is not null)
        {
            var psychologist = PsychologistMapper.ToEntity(userModel.Psychologist);
            user.Psychologist = psychologist;
        }
        else
        {
            user.Psychologist = null;
        }

        ICollection<Session> sessions = userModel.Sessions.Select(SessionMapper.ToEntity).ToList();
        foreach (var session in sessions)
        {
            user.Sessions.Add(session);
        }

        return user;
    }

    public static async Task<UserModel> ToModel(User user, ApplicationDbContext context)
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

        if (user.Psychologist is not null)
        {
            var psychologist = await PsychologistMapper.ToModel(user.Psychologist, context);
            userModel.Psychologist = psychologist;
        }
        else
        {
            userModel.Psychologist = null;
        }

        List<Task<SessionModel>> sessions = user.Sessions.Select(p => SessionMapper.ToModel(p, context)).ToList();
        foreach (var session in sessions)
        {
            userModel.Sessions.Add(await session);
        }

        return userModel;
    }
}