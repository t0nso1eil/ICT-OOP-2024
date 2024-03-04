namespace MentallHealthSupport.Application.Models.Entities;

public class Psychologist
{
    public User? User { get; set; }

    public string? Specialization { get; set; }

    public DateOnly ExperienceStartDate { get; set; }

    public uint ExperienceYears { get; set; }

    public decimal PricePerHour { get; set; }

    public float Rate { get; set; }

    public IEnumerable<Review>? Reviews { get; set; }

    public IEnumerable<Spot>? Spots { get; set; }
}