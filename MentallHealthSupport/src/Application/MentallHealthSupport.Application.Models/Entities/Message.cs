namespace MentallHealthSupport.Application.Models.Entities;

public class Message
{
    public Chat? Chat { get; set; }

    public User? Sender { get; set; }

    public string? MessageText { get; set; }

    public DateTime SentTime { get; set; }
}
