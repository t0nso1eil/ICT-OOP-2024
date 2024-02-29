namespace MentallHealthSupport.Application.Models.Entities;

public class Review
{
    public Guid Id { get; }

    public Guid ClientId { get; }

    public Guid PsychologistId { get; }

    public uint Rate { get; set; }

    public string? Description { get; set; }

    public DateTime PostTime { get; set; }
}