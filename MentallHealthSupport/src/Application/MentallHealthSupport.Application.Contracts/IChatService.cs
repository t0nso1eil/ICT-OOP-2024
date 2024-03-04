namespace MentallHealthSupport.Application.Contracts;

using MentallHealthSupport.Application.Models.Entities;

public interface IChatService
{
    public void CreateChat(Guid user1Id, Guid user2Id);

    public void DeleteChat(Guid chatId);
}