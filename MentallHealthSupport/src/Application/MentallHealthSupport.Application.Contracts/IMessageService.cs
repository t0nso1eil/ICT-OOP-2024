namespace MentallHealthSupport.Application.Contracts;

public interface IMessageService
{
    public void SendMessageByClient(Guid clientId, string messageText);

    public void SendMessageByPsychologist(Guid psychologistId, string messageText);

    public void UpdateMessage(Guid messageId, string messageText);

    public void DeleteMessage(Guid messageId);
    
    public IEnumerable<Message> GetChatMessages(Guid chatId);
    
}