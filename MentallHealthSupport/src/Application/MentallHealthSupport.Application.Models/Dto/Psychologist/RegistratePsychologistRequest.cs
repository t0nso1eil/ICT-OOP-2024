namespace MentallHealthSupport.Application.Models.Dto.Psychologist;

public record RegistratePsychologistRequest(
    string FirstName,
    string LastName,
    string Email,
    string PhoneNumber,
    string Password,
    DateOnly Birthday,
    string Sex,
    string AdditionalInfo,
    string Specialization,
    DateOnly ExperienceStartDate,
    decimal PricePerHour);