namespace MentallHealthSupport.Application.Contracts;

using MentallHealthSupport.Application.Models.Entities;

public interface IPsychologistService
{
    public void CreatePsychologist(string firstName, string lastName, string email, string password, DateOnly birthday, string sex, string specialization, DateOnly experienceStartDate, string additionalInfo, decimal pricePerHour);

    public Psychologist GetPsychologist(Guid psychologistId);

    public IEnumerable<Psychologist> GetAllPsychologists();

    public void UpdatePsychologist(Guid psychologistId, string firstName, string lastName, string password, string additionalInfo, decimal pricePerHour);

    public void UpdatePsychologistFullName(Guid psychologistId, string firstName, string lastName);

    public void UpdatePsychologistPassword(Guid psychologistId, string password);

    public void UpdatePsychologistPricePerHour(Guid psychologistId, decimal pricePerHour);

    public void UpdatePsychologistSpecialization(Guid psychologistId, string specialization);

    public void UpdatePsychologistAdditionalInfo(Guid psychologistId, string additionalInfo);

    public IEnumerable<Psychologist> GetPsychologistsByPrice(decimal priceMin, decimal priceMax);

    public IEnumerable<Psychologist> GetPsychologistsByRate(decimal rateMin, decimal rateMax);

    public void CreateNewSpot(Guid psychologistId, DateOnly date, DateTime start, DateTime end);

    public void UpdateSpotStatus(Guid spotId, string status);

    public IEnumerable<Spot> GetPsychologistFreeSpots(Guid psychologistId);

    public IEnumerable<Spot> GetPsychologistSchedule(Guid psychologistId);

    public IEnumerable<Review> GetPsychologistReviews(Guid psychologistId);
}