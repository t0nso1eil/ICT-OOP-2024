#pragma warning disable SA1028
#pragma warning disable SA1508

using MentallHealthSupport.Application.Models.Entities;

namespace MentallHealthSupport.Application.Abstractions.Persistence.Repositories;

public interface IPsychologistRepository
{
    Task CreatePsychologist(Psychologist psychologist);

    Task<Psychologist> GetPsychologistById(Guid id);

    Task UpdatePsychologist(Psychologist newPsychologist);

    Task<ICollection<Psychologist>> GetAllPsychologists();
    
    Task<ICollection<Psychologist>> GetPsychologistsByPrice(decimal priceMin, decimal priceMax);

    Task<ICollection<Psychologist>> GetPsychologistsByRate(float rateMin, float rateMax);

}