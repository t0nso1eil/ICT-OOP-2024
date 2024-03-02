namespace MentallHealthSupport.Application.Models.Entities;

public class Psychologist
{
    public Guid Id { get; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? Email { get; set; }

    public string? Password { get; set; }

    public DateOnly Birthday { get; set; }

    public uint Age => (uint)((DateTime.Now - Birthday.ToDateTime()).TotalDays / 365);

    public string? Sex { get; set; }

    public string? Specialization { get; set; }

    public DateOnly ExperienceStartDate { get; private set; }

    public uint ExperienceYears => (unit)((DateTime.Now - ExperienceStartDate.ToDateTime()).TotalDays/365)

    public string? AdditionalInfo { get; set; }

    public decimal PricePerHour { get; set; }

    public float Rate { get; private set; }

    public DateTime RegistrationDate { get; private set; }

    public IEnumerable<Review>? Reviews { get; set; }
    
    public IEnumerable<Chat>? Chats { get; set; }
    
    public IEnumerable<Message>? Messages { get; set; }
    
    public IEnumerable<Spot>? Spots { get; set; }
}