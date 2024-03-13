namespace MentallHealthSupport.Infrastructure.Persistence.Models;

public class SessionModel
{
    public Guid Id { get; set; }

    public UserModel? User { get; set; }
}