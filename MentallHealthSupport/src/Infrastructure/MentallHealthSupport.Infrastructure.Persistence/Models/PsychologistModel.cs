namespace MentallHealthSupport.Infrastructure.Persistence.Models;

public class PsychologistModel
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    
    public string Specialization { get; set; } = null!;

    public DateOnly ExperienceStartDate { get; set; }

    public uint ExperienceYears { get; set; }

    public decimal PricePerHour { get; set; }

    public float? Rate { get; set; }
}