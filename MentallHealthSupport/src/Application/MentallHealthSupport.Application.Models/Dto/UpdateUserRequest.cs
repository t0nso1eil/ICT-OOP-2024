namespace MentallHealthSupport.Application.Models.Dto;

public record UpdateUserRequest(
    string FirstName,
    string LastName,
    string PhoneNumber,
    string Password,
    string AdditionalInfo);