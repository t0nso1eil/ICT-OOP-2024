namespace MentallHealthSupport.Application.Models.Dto;

public record UserPublicInfo(string FirstName, string LastName, string Email, string PhoneNumber, DateOnly BirthDay, uint Age, string AdditionalInfo, DateTime RegistrationTime);