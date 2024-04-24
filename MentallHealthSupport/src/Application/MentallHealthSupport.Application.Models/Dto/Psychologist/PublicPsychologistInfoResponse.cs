namespace MentallHealthSupport.Application.Models.Dto.Psychologist;

public record PublicPsychologistInfoResponse(
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
    float? Rate)
{
    public static PublicPsychologistInfoResponse FromPsychologist(Entities.Psychologist psychologist)
    {
        return new PublicPsychologistInfoResponse(
            psychologist.User.FirstName,
            psychologist.User.LastName,
            psychologist.User.Email,
            psychologist.User.PhoneNumber,
            psychologist.User.Birthday,
            psychologist.User.Age,
            psychologist.User.AdditionalInfo,
            psychologist.User.RegistrationDate,
            psychologist.Specialization,
            psychologist.ExperienceStartDate,
            psychologist.ExperienceYears,
            psychologist.PricePerHour,
            psychologist.Rate);
    }
}