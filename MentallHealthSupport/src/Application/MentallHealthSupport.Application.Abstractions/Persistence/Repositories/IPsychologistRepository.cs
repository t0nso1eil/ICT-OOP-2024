using MentallHealthSupport.Application.Models.Entities;

namespace MentallHealthSupport.Application.Abstractions.Persistence.Repositories;

public interface IPsychologistRepository
{
    Task CreatePsychologist(Psychologist psychologist);

    Task<Psychologist> GetPsychologistById(Guid id);

    Task UpdatePsychologist(Psychologist newPsychologist);

    ICollection<Psychologist> GetAllPsychologists();

    ICollection<Psychologist> GetPsychologistsByPrice(decimal priceMin, decimal priceMax);

    ICollection<Psychologist> GetPsychologistsByRate(float rateMin, float rateMax);
}