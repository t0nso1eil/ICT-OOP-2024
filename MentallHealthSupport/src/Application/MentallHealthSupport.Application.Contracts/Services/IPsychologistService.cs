namespace MentallHealthSupport.Application.Contracts.Services;

using MentallHealthSupport.Application.Models.Entities;

public interface IPsychologistService
{
    public void CreatePsychologist(string firstName, string lastName, string email, string password, DateOnly birthday, string sex, string specialization, DateOnly experienceStartDate, string additionalInfo, decimal pricePerHour);

    public Psychologist GetPsychologist(Guid psychologistId);

    public void UpdatePsychologist(Guid psychologistId, string firstName, string lastName, string password, string additionalInfo, string specialization, decimal pricePerHour);

    public IEnumerable<Psychologist> GetAllPsychologists();

    public IEnumerable<Psychologist> GetPsychologistsByPrice(decimal priceMin, decimal priceMax);

    public IEnumerable<Psychologist> GetPsychologistsByRate(decimal rateMin, decimal rateMax);
}