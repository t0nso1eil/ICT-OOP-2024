namespace MentallHealthSupport.Infrastructure.Persistence.Models;

public class ReviewModel
{
    public Guid Id { get; set; }

    public Guid UserId { get; set; }

    public Guid PsychologistId { get; set; }

    public uint Rate { get; set; }

    public string Description { get; set; } = null!;

    public DateTime PostTime { get; set; }
}