namespace MentallHealthSupport.Infrastructure.Persistence.Models;

public class ChatModel
{
    public Guid Id { get; set; }

    public List<UserModel> Users { get; set; } = new List<UserModel>();

    public ICollection<MessageModel> Messages { get; set; } = new List<MessageModel>();
}