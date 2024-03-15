namespace MentallHealthSupport.Application.Models.Dto;

public record PublicPsychologistInfoResponse
(
    string FirstName,
    string LastName,
    string Email,
    string PhoneNumber,
    DateOnly BirthDay,
    uint Age,
    string AdditionalInfo,
    DateTime RegistrationTime,
    string Specialization,
    DateOnly ExperienceStartDate,
    uint ExperienceYears,
    decimal PricePerHour,
    float? Rate);