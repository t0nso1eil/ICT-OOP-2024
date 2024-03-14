using MentallHealthSupport.Application.Models.Entities;

namespace MentallHealthSupport.Infrastructure.Persistence.Models;

public class SessionModel
{
    public Guid Id { get; set; }
    
    public UserModel User { get; set; } = null!;
    
    public SpotModel Spot { get; set; } = null!;
    
    public string Status { get; set; } = null!;
    
    public decimal Price { get; set; }
}