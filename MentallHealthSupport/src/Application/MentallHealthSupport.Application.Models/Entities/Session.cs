namespace MentallHealthSupport.Application.Models.Entities;

public class Session
{
    public User? Client { get; set; }

    public Spot? Spot { get; set; }

    public string? Status { get; set; }

    public decimal Price { get; set; }
}