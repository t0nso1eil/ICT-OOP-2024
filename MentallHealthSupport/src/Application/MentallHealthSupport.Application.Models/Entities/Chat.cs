#pragma warning disable CA2227

namespace MentallHealthSupport.Application.Models.Entities;

public class Chat
{
    public Guid Id { get; set; }

    public ICollection<User> Users { get; } = new List<User>();

    public ICollection<Message> Messages { get; set; } = new List<Message>();
}