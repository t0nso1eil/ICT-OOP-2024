namespace MentallHealthSupport.Application.Models.Entities;

public class Review
{
    public Guid Id { get; set; }
    
    public User User { get; set; } = null!;
    
    public Psychologist Psychologist { get; set; } = null!;
    
    public uint Rate { get; set; }

    public string Description { get; set; } = null!;

    public DateTime PostTime { get; set; }
}