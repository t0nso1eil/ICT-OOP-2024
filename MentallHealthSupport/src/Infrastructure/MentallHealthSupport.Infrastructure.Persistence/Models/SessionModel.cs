namespace MentallHealthSupport.Infrastructure.Persistence.Models;

public class SessionModel
{
    public Guid Id { get; set; }

    public Guid UserId { get; set; }

    public UserModel User { get; set; } = null!;

    public Guid SpotId { get; set; }

    public SpotModel Spot { get; set; } = null!;

    public string Status { get; set; } = null!;

    public decimal Price { get; set; }
}