namespace MentallHealthSupport.Application.Models.Entities;

public class Chat
{
    public User? User1 { get; set; }

    public User? User2 { get; set; }

    public IEnumerable<Message>? Messages { get; set; }
}