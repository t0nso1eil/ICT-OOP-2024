namespace MentallHealthSupport.Application.Models.Entities;

public class Session
{
    public Guid Id { get; set; }

    public Guid ClientId { get; set; }
    
    public Client? Client { get; set; }

    public Guid SpotId { get; set; }
    
    public Spot? Spot { get; set; }

    public string? Status { get; set; }

    public decimal Price { get; set; }
    
}