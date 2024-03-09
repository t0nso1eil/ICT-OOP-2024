namespace MentallHealthSupport.Application.Models.Entities;

public class Session
{
    public Guid Id { get; set; }

    public User Client { get; set; } = null!;

    public Spot Spot { get; set; } = null!;

    public string Status { get; set; } = null!;

    public decimal Price { get; set; }
}