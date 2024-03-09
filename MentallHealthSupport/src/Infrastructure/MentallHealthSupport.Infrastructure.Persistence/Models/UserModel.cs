namespace MentallHealthSupport.Infrastructure.Persistence.Models;

public class UserModel
{
    public Guid Id { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string PhoneNumber { get; set; } = null!;

    public string Password { get; set; } = null!;

    public DateOnly Birthday { get; set; }

    public uint Age { get; set; }

    public string Sex { get; set; } = null!;

    public string AdditionalInfo { get; set; } = null!;

    public DateTime RegistrationDate { get; set; }

    public ICollection<SessionModel>? Sessions { get; set; } = new List<SessionModel>();

    public ICollection<MessageModel>? Messages { get; set; } = new List<MessageModel>();

    public ICollection<ChatModel> Chats { get; set; } = new List<ChatModel>();
}