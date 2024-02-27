namespace MentallHealthSupport.Application.Models.Entities;

public class Client
{
    public Guid Id { get; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? Email { get; set; }

    public string? PhoneNumber { get; set; }

    public string? Password { get; set; }

    public DateOnly Birthday { get; set; }

    public uint Age { get; private set; }

    public string? Sex { get; set; }

    public string? AdditionalInfo { get; set; }

    public DateTime RegistrationDate { get; private set; }
}