namespace MentallHealthSupport.Infrastructure.Persistence.Models;

public class ReviewModel
{
    public Guid Id { get; set; }
    public UserModel User { get; set; } = null!;
    public PsychologistModel Psychologist { get; set; } = null!;
    public uint Rate { get; set; }
    public string Description { get; set; } = null!;
    public DateTime PostTime { get; set; }
}