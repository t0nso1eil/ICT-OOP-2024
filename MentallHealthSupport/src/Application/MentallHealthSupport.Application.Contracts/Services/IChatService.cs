#pragma warning disable CA1002

using MentallHealthSupport.Application.Models.Entities;

namespace MentallHealthSupport.Application.Contracts.Services;
public interface IChatService
{
    public void CreateChat(List<User> users);

    public void DeleteChat(Guid chatId);
}