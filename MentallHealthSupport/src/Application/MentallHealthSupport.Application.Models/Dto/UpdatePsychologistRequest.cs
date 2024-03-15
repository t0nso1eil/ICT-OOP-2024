namespace MentallHealthSupport.Application.Models.Dto;

public record UpdatePsychologistRequest(
    string? FirstName,
    string? LastName,
    string? PhoneNumber,
    string? Password,
    string? AdditionalInfo,
    string? Specialization,
    decimal? PricePerHour);