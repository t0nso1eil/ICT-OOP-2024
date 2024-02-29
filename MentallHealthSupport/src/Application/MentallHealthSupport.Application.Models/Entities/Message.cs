namespace MentallHealthSupport.Application.Models.Entities;

public class Message
{
    public Guid Id { get; }

    public Guid ChatId { get; }

    public Guid PsychologistId { get; }

    public string? MessageText { get; set; }

    public DateTime SentTime { get; }
}