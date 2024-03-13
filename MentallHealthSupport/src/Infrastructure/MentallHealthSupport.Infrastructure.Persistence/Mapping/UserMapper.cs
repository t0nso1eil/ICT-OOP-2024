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

        ICollection<Message> messages = userModel.Messages.Select(MessageMapper.ToEntity).ToList();
        foreach (var message in messages)
        {
            user.Messages.Add(message);
        }

        ICollection<Chat> chats = userModel.Chats.Select(ChatMapper.ToEntity).ToList();
        foreach (var chat in chats)
        {
            user.Chats.Add(chat);
        }

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

        if (user.Psychologist is not null)
        {
            var psychologist = PsychologistMapper.ToModel(user.Psychologist);
            userModel.Psychologist = psychologist;
        }
        else
        {
            userModel.Psychologist = null;
        }

        ICollection<SessionModel> sessions = user.Sessions.Select(SessionMapper.ToModel).ToList();
        foreach (var session in sessions)
        {
            userModel.Sessions.Add(session);
        }

        ICollection<MessageModel> messages = user.Messages.Select(MessageMapper.ToModel).ToList();
        foreach (var message in messages)
        {
            userModel.Messages.Add(message);
        }

        ICollection<ChatModel> chats = user.Chats.Select(ChatMapper.ToModel).ToList();
        foreach (var chat in chats)
        {
            userModel.Chats.Add(chat);
        }

        return userModel;
    }
}