namespace MentallHealthSupport.Infrastructure.Persistence.Models;

public class SessionModel
{
    public Guid Id { get; set; }

    public Guid UserId { get; set; }

    public Guid SpotId { get; set; }

    public string Status { get; set; } = null!;

    public decimal Price { get; set; }
}