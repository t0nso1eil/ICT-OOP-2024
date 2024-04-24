namespace MentallHealthSupport.Infrastructure.Persistence.Models;

public class SpotModel
{
    public Guid Id { get; set; }

    public Guid PsychologistId { get; set; }

    public DateOnly Date { get; set; }

    public DateTime HourStart { get; set; }

    public DateTime HourEnd { get; set; }

    public string Status { get; set; } = null!;
}