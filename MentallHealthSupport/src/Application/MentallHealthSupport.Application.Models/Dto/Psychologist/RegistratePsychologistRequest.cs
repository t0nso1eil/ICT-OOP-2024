using MentallHealthSupport.Application.Models.Dto.User;

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
    decimal PricePerHour)
{
    public RegistrateUserRequest ToRegistrateUserRequest()
    {
        return new RegistrateUserRequest(
            FirstName,
            LastName,
            Email,
            PhoneNumber,
            Password,
            Birthday,
            Sex,
            AdditionalInfo);
    }
}