namespace MentallHealthSupport.Application.Models.Dto.User
{
    public record PublicUserInfoResponse(
        string FirstName,
        string LastName,
        string Email,
        string PhoneNumber,
        DateOnly BirthDay,
        uint Age,
        string AdditionalInfo,
        DateTime RegistrationTime)
    {
        public static PublicUserInfoResponse FromUser(Entities.User user)
        {
            return new PublicUserInfoResponse(
                user.FirstName,
                user.LastName,
                user.Email,
                user.PhoneNumber,
                user.Birthday,
                user.Age,
                user.AdditionalInfo,
                user.RegistrationDate);
        }
    }
}