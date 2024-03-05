namespace MentallHealthSupport.Application.Models.Entities;

public class Spot
{
    public Psychologist? Psychologist { get; set; }

    public DateOnly Date { get; set; }

    public DateTime HourStart { get; set; }

    public DateTime HourEnd { get; set; }

    public string? Status { get; set; }

    public Session? Session { get; set; }
}