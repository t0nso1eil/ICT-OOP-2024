namespace MentallHealthSupport.Application.Models.Entities;

public class Message
{
    public Guid Id { get; }

    public Guid ChatId { get; set; }

    public Chat? Chat { get; set; }

    public Guid PsychologistId { get; set; }

    public Psychologist? Psychologist { get; set; }

    public string? MessageText { get; set; }

    public DateTime SentTime { get; private set; }
    
