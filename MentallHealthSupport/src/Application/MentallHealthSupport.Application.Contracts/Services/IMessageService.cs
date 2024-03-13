using MentallHealthSupport.Application.Models.Entities;

namespace MentallHealthSupport.Application.Contracts.Services;
public interface IMessageService
{
    public void SendMessage(Guid chatId, Guid senderId, string messageText);

    public void UpdateMessage(Guid messageId, string messageText);

    public void DeleteMessage(Guid messageId);

    public IEnumerable<Message> GetChatMessages(Guid chatId);
}