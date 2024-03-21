namespace MentallHealthSupport.Application.Models.Dto.Session;

public record PublicSessionInfoResponse(
    string PsychologistFirstName,
    string PsychologistLastName,
    string UserFirstName,
    string UserLastName,
    DateOnly Date,
    DateTime StartTime,
    DateTime EndTime,
    string Status,
    decimal Price);