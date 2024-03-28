using MentallHealthSupport.Application.Models.Dto.User;

namespace MentallHealthSupport.Application.Models.Dto.Psychologist;

public record UpdatePsychologistRequest(
    string? FirstName,
    string? LastName,
    string? PhoneNumber,
    string? Password,
    string? AdditionalInfo,
    string? Specialization,
    decimal? PricePerHour)
{
    public UpdateUserRequest ToUpdateUserRequest()
    {
        return new UpdateUserRequest(FirstName, LastName, PhoneNumber, Password, AdditionalInfo);
    }
}