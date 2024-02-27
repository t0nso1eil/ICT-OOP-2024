namespace MentallHealthSupport.Application.Models.Entities;

public class Session
{
    public Guid Id { get; }

    public Guid ClientId { get; set; }

    public Guid SpotId { get; set; }

    public string? Status { get; set; }

    public decimal Price { get; set; }
}