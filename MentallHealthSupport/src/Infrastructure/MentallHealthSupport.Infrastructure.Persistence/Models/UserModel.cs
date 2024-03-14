namespace MentallHealthSupport.Infrastructure.Persistence.Models;

public class UserModel
{
    public Guid Id { get; set; }
    
    public ICollection<SessionModel> Sessions { get; } = new List<SessionModel>();
    
    
}