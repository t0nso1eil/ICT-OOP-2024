﻿#pragma warning disable CA1724

namespace MentallHealthSupport.Application.Models.Entities;

public class User
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

    public ICollection<Session> Sessions { get; set; } = new List<Session>();

    public ICollection<Message> Messages { get; set; } = new List<Message>();

    public ICollection<Chat> Chats { get; set; } = new List<Chat>();
}