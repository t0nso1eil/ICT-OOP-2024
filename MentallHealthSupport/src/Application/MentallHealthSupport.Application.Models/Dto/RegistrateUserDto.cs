namespace MentallHealthSupport.Application.Models.Dto;

public record RegistrateUserDto(Guid Id, string FirstName, string LastName, string Email, string PhoneNumber, string PasswordHash, DateOnly Birthday, string Sex, string AdditionalInfo);