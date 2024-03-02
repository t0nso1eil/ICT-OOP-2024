namespace MentallHealthSupport.Application.Models.Entities;

public class Client
{
    public Guid Id { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? Email { get; set; }

    public string? PhoneNumber { get; set; }

    public string? Password { get; set; }

    public DateOnly Birthday { get; set; }

    public uint Age { get; set; }

    public string? Sex { get; set; }

    public string? AdditionalInfo { get; set; }

    public DateTime RegistrationDate { get; set; }
    
    public IEnumerable<Session>? Sessions { get; set; }
    
    public IEnumerable<Payment>? Payments { get; set; }
    
    public IEnumerable<Message>? Messages { get; set; }
    
    public IEnumerable<Chat>? Chats { get; set; }
}