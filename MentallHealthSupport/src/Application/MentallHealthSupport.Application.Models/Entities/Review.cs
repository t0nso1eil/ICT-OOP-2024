namespace MentallHealthSupport.Application.Models.Entities;

public class Review
{
    public User? Client { get; set; }

    public Psychologist? Psychologist { get; set; }

    public uint Rate { get; set; }

    public string? Description { get; set; }

    public DateTime PostTime { get; set; }
}