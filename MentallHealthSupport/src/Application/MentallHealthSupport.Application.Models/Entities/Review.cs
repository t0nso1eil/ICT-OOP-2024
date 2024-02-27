namespace MentallHealthSupport.Application.Models.Entities;

public class Review
{
    public Guid Id { get; }

    public Guid ClientId { get; set; }

    public Guid PsychologistId { get; set; }

    public uint Rate { get; set; }

    public string? Description { get; set; }

    public DateTime PostTime { get; private set; }
}