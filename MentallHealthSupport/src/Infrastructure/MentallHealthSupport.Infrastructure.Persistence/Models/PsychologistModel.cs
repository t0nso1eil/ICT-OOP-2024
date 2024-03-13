namespace MentallHealthSupport.Infrastructure.Persistence.Models;

public class PsychologistModel
{
    public Guid Id { get; set; }

    public UserModel User { get; set; } = null!;
}