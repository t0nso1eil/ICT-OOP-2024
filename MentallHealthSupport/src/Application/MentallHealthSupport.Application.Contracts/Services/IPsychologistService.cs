using MentallHealthSupport.Application.Models.Dto;
using MentallHealthSupport.Application.Models.Entities;

namespace MentallHealthSupport.Application.Contracts.Services;
public interface IPsychologistService
{
    public Task CreatePsychologist(RegistratePsychologistRequest registratePsychologistRequest);

    public Task<PublicPsychologistInfoResponse> GetPsychologist(Guid psychologistId);

    public Task UpdatePsychologist(Guid psychologistId, UpdatePsychologistRequest updatePsychologistRequest);

    public ICollection<PublicPsychologistInfoResponse> GetAllPsychologists();

    public ICollection<PublicPsychologistInfoResponse> GetPsychologistsByPrice(decimal priceMin, decimal priceMax);

    public ICollection<PublicPsychologistInfoResponse> GetPsychologistsByRate(float rateMin, float rateMax);
}