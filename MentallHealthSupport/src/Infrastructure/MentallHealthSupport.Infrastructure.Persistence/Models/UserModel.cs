namespace MentallHealthSupport.Infrastructure.Persistence.Models;

public class UserModel
{
    public Guid Id { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string PhoneNumber { get; set; } = null!;

    public string PasswordHash { get; set; } = null!;

    public DateOnly Birthday { get; set; }

    public uint Age { get; set; }

    public string Sex { get; set; } = null!;

    public string AdditionalInfo { get; set; } = null!;

    public DateTime RegistrationDate { get; set; }

    public bool IsPsychologist { get; set; }

    public PsychologistModel? Psychologist { get; set; }

    public ICollection<SessionModel> Sessions { get; } = new List<SessionModel>();

    public ICollection<MessageModel> Messages { get; } = new List<MessageModel>();

    public ICollection<ChatModel> Chats { get; } = new List<ChatModel>();
}