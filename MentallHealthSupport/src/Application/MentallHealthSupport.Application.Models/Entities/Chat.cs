namespace MentallHealthSupport.Application.Models.Entities;

public class Chat
{
    public Guid Id { get; set; }

    public List<User> Users { get; set; } = new List<User>();

    public ICollection<Message> Messages { get; set; } = new List<Message>();
}