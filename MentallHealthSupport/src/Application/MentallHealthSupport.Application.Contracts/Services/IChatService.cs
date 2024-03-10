namespace MentallHealthSupport.Application.Contracts.Services;

using MentallHealthSupport.Application.Models.Entities;

public interface IChatService
{
    public void CreateChat(List<User> users);

    public void DeleteChat(Guid chatId);
}