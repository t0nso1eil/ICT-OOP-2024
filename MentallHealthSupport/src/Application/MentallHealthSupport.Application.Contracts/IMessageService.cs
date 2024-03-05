namespace MentallHealthSupport.Application.Contracts;

using MentallHealthSupport.Application.Models.Entities;

public interface IMessageService
{
    public void SendMessage(Guid chatId, Guid senderId, string messageText);

    public void UpdateMessage(Guid messageId, string messageText);

    public void DeleteMessage(Guid messageId);

    public IEnumerable<Message> GetChatMessages(Guid chatId);
}