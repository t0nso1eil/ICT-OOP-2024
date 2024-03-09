namespace MentallHealthSupport.Application.Models.Entities;

public class Message
{
    public Guid Id { get; set; }

    public Chat Chat { get; set; } = null!;

    public User Sender { get; set; } = null!;

    public string MessageText { get; set; } = null!;

    public DateTime SentTime { get; set; }
}
