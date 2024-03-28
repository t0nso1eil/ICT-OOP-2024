#pragma warning disable SA1507
#pragma warning disable SA1508
#pragma warning disable SA1024
#pragma warning disable SA1028
#pragma warning disable IDE0008
#pragma warning disable SA1117
#pragma warning disable SA1116
#pragma warning disable  IDE0161

using MentallHealthSupport.Application.Abstractions.Persistence.Repositories;
using MentallHealthSupport.Application.Contracts.Services;
using MentallHealthSupport.Application.Models.Dto.Psychologist;
using MentallHealthSupport.Application.Models.Entities;
using static System.DateTime;

namespace MentallHealthSupport.Application.Services;

public class PsychologistService: IPsychologistService
{
    private readonly IPsychologistRepository _psychologistRepository;
    private readonly IUserRepository _userRepository;
    private readonly IUserService _userService;
    
    public PsychologistService(IPsychologistRepository psychologistRepository, IUserRepository userRepository, IUserService userService)
    {
        _psychologistRepository = psychologistRepository;
        _userRepository = userRepository;
        _userService = userService;
    }
    
    public async Task<Guid> CreatePsychologist(RegistratePsychologistRequest registratePsychologistRequest)
    {
        var userInfo = registratePsychologistRequest.ToRegistrateUserRequest();

        Guid id = await _userService.CreateUser(userInfo);
        await _userRepository.UpdateStatus(id, true);
        var user = await _userRepository.GetUserById(id);
        var psycho = new Psychologist
        {
            Id = Guid.NewGuid(),
            User = user,
            Specialization = registratePsychologistRequest.Specialization,
            ExperienceStartDate = registratePsychologistRequest.ExperienceStartDate,
            ExperienceYears = (uint)(Today.Year - registratePsychologistRequest.ExperienceStartDate.Year),
            PricePerHour = registratePsychologistRequest.PricePerHour,
        };
        
        await _psychologistRepository.CreatePsychologist(psycho);
        return psycho.Id;
    }
    

    public async Task<PublicPsychologistInfoResponse> GetPsychologist(Guid psychologistId)
    {
        var psycho = await _psychologistRepository.GetPsychologistById(psychologistId);
        return PublicPsychologistInfoResponse.FromPsychologist(psycho);
    }

    public async Task<PublicPsychologistInfoResponse> UpdatePsychologist(Guid psychologistId, UpdatePsychologistRequest updatePsychologistRequest)
    {
        var psycho = await _psychologistRepository.GetPsychologistById(psychologistId);
        var user = await _userRepository.GetUserById(psycho.User.Id);
        var userInfo = updatePsychologistRequest.ToUpdateUserRequest();
        await _userService.UpdateUser(user.Id, userInfo);
        
        psycho.Specialization = updatePsychologistRequest.Specialization ?? psycho.Specialization;
        psycho.PricePerHour = updatePsychologistRequest.PricePerHour ?? psycho.PricePerHour;
        await _psychologistRepository.UpdatePsychologist(psycho);
        psycho = await _psychologistRepository.GetPsychologistById(psychologistId);
        return PublicPsychologistInfoResponse.FromPsychologist(psycho);
    }

    public async Task<ICollection<PublicPsychologistInfoResponse>> GetAllPsychologists()
    {
        var psychos = await _psychologistRepository.GetAllPsychologists();
        return psychos.Select(p => PublicPsychologistInfoResponse.FromPsychologist(p)).ToList();
    }

    public async Task<ICollection<PublicPsychologistInfoResponse>> GetPsychologistsByPrice(decimal priceMin, decimal priceMax)
    {
        var psychos = await _psychologistRepository.GetPsychologistsByPrice(priceMin, priceMax);
        return psychos.Select(p => PublicPsychologistInfoResponse.FromPsychologist(p)).ToList();
    }

    public async Task<ICollection<PublicPsychologistInfoResponse>> GetPsychologistsByRate(float rateMin, float rateMax)
    {
        var psychos = await _psychologistRepository.GetPsychologistsByRate(rateMin, rateMax);
        return psychos.Select(p => PublicPsychologistInfoResponse.FromPsychologist(p)).ToList();

    }
}