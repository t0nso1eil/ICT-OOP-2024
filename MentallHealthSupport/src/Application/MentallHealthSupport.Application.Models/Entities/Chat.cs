namespace MentallHealthSupport.Application.Models.Entities;

public class Chat
{
    public Guid Id { get; }

    public Guid ClientId { get; }
    
    public Guid PsychologistId { get; }

    public IEnumerable<Message>? Messages { get; set; }
}