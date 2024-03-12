namespace MentallHealthSupport.Infrastructure.Persistence.Models;

public class UserModel
{
    public Guid Id; 
    public ICollection<SessionModel> Sessions { get; set; } = new List<SessionModel>();

}