namespace MentallHealthSupport.Infrastructure.Persistence.Models;

public class SpotModel
{
    public Guid Id { get; set; }

    public PsychologistModel Psychologist { get; set; } = null!;

    public DateOnly Date { get; set; }

    public DateTime HourStart { get; set; }

    public DateTime HourEnd { get; set; }

    public string Status { get; set; } = null!;

    public SessionModel Session { get; set; } = null!;
}