namespace MentallHealthSupport.Application.Models.Entities;

public class Psychologist
{
    public Guid Id { get; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? Email { get; set; }

    public string? Password { get; set; }

    public DateOnly Birthday { get; set; }

    public uint Age { get; private set; }

    public string? Sex { get; set; }

    public string? Specialization { get; set; }

    public DateOnly ExperienceStartDate { get; set; }

    public uint ExperienceYears { get; private set; }

    public string? AdditionalInfo { get; set; }

    public decimal PricePerHour { get; set; }

    public float Rate { get; private set; }

    public DateTime RegistrationDate { get; private set; }

    public IEnumerable<Review>? Reviews { get; set; }
}