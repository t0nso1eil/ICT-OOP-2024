namespace MentallHealthSupport.Application.Models.Entities;

public class Chat
{
    public Guid Id { get; set; }

    public Guid ClientId { get; set; }
    
    public Client? Client { get; set; }
    
    public Guid PsychologistId { get; set; }
    
    public Psychologist? Psychologist { get; set; }
    
    public IEnumerable<Message>? Messages { get; set; }
    
}