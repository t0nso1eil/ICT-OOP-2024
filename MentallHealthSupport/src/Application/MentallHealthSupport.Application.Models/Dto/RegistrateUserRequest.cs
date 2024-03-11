namespace MentallHealthSupport.Application.Models.Dto;

public record RegistrateUserRequest(
    string FirstName,
    string LastName,
    string Email,
    string PhoneNumber,
    string Password,
    DateOnly Birthday,
    string Sex,
    string AdditionalInfo);