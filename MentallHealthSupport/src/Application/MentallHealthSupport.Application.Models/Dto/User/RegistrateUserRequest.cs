namespace MentallHealthSupport.Application.Models.Dto.User
{
    public record RegistrateUserRequest(
        string FirstName,
        string LastName,
        string Email,
        string PhoneNumber,
        string Password,
        DateOnly Birthday,
        string Sex,
        string AdditionalInfo)
    {
        public Entities.User CreateUser()
        {
            return new Entities.User
            {
                Id = new Guid(),
                FirstName = FirstName,
                LastName = LastName,
                Email = Email,
                PhoneNumber = PhoneNumber,
                PasswordHash = Password,
                Birthday = Birthday,
                Age = (uint)CalculateAge(Birthday),
                Sex = Sex,
                AdditionalInfo = AdditionalInfo,
                RegistrationDate = DateTime.Now,
            };
        }

        private int CalculateAge(DateOnly birthday)
        {
            DateTime dateTime = DateTime.Now;
            DateOnly currentDate = new DateOnly(dateTime.Year, dateTime.Month, dateTime.Day);
            int age = currentDate.Year - birthday.Year;
            if (currentDate.DayOfYear < birthday.DayOfYear)
            {
                age--;
            }

            return age;
        }
    }
}