#pragma warning disable CA1724

namespace MentallHealthSupport.Application.Models.Entities;

public class Spot
{
    public Guid Id { get; set; }

    public Psychologist Psychologist { get; set; } = null!;

    public DateOnly Date { get; set; }

    public DateTime HourStart { get; set; }

    public DateTime HourEnd { get; set; }

    public string Status { get; set; } = null!;

    public Session Session { get; set; } = null!;
}