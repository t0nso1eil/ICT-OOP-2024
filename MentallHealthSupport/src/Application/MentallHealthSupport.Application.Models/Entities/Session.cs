namespace MentallHealthSupport.Application.Models.Entities;

public class Session
{
    public Guid Id { get; }

    public Guid ClientId { get; }

    public Guid SpotId { get; }

    public string? Status { get; set; }

    public decimal Price { get; set; }
}