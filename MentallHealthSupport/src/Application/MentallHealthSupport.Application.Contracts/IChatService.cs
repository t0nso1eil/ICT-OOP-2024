namespace MentallHealthSupport.Application.Contracts;

using MentallHealthSupport.Application.Models.Entities;

public interface IChatService
{
    public void CreateChat(Guid clientId, Guid psychologistId);

    public void DeleteChat(Guid chatId);
    
}