using MentallHealthSupport.Application.Models.Dto.Psychologist;

namespace MentallHealthSupport.Application.Contracts.Services;
public interface IPsychologistService
{
    public Task<Guid> CreatePsychologist(RegistratePsychologistRequest registratePsychologistRequest);

    public Task<PublicPsychologistInfoResponse> GetPsychologist(Guid psychologistId);

    public Task<PublicPsychologistInfoResponse> UpdatePsychologist(Guid psychologistId, UpdatePsychologistRequest updatePsychologistRequest);

    public Task<ICollection<PublicPsychologistInfoResponse>> GetAllPsychologists();

    public Task<ICollection<PublicPsychologistInfoResponse>> GetPsychologistsByPrice(decimal priceMin, decimal priceMax);

    public Task<ICollection<PublicPsychologistInfoResponse>> GetPsychologistsByRate(float rateMin, float rateMax);
}