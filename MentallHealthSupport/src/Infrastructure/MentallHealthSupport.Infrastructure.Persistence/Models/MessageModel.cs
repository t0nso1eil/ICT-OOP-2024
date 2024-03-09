namespace MentallHealthSupport.Infrastructure.Persistence.Models;

public class MessageModel
{
    public Guid Id { get; set; }

    public ChatModel Chat { get; set; } = null!;

    public UserModel Sender { get; set; } = null!;

    public string MessageText { get; set; } = null!;

    public DateTime SentTime { get; set; }
}