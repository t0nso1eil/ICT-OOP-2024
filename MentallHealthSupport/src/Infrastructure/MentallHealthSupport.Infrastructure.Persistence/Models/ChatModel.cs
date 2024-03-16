namespace MentallHealthSupport.Infrastructure.Persistence.Models;

public class ChatModel
{
    public Guid Id { get; set; }

    public ICollection<UserModel> Users { get; } = new List<UserModel>();

    public ICollection<MessageModel> Messages { get; } = new List<MessageModel>();
}