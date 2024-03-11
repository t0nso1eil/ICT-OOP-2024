namespace MentallHealthSupport.Application.Models.Dto;

public record PublicUserInfoResponse(
    string FirstName,
    string LastName,
    string Email,
    string PhoneNumber,
    DateOnly BirthDay,
    uint Age,
    string AdditionalInfo,
    DateTime RegistrationTime);