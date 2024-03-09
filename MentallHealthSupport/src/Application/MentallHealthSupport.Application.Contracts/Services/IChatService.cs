namespace MentallHealthSupport.Application.Contracts.Services;

public interface IChatService
{
    public void CreateChat();

    public void DeleteChat(Guid chatId);
}