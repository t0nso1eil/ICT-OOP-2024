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
using MentallHealthSupport.Application.Models.Dto.User;
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
        var userInfo = DtoPsychologistToUser(registratePsychologistRequest);

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
        return CreatePsychologistInfoResponse(psycho);
    }

    public async Task UpdatePsychologist(Guid psychologistId, UpdatePsychologistRequest updatePsychologistRequest)
    {
        var psycho = await _psychologistRepository.GetPsychologistById(psychologistId);
        var user = await _userRepository.GetUserById(psycho.User.Id);
        var userInfo = DtoUpdatePsychologistToUser(updatePsychologistRequest);
        await _userService.UpdateUser(user.Id, userInfo);
        
        psycho.Specialization = updatePsychologistRequest.Specialization ?? psycho.Specialization;
        psycho.PricePerHour = updatePsychologistRequest.PricePerHour ?? psycho.PricePerHour;
        await _psychologistRepository.UpdatePsychologist(psycho);
    }

    public ICollection<PublicPsychologistInfoResponse> GetAllPsychologists()
    {
        var psychos = _psychologistRepository.GetAllPsychologists();
        return psychos.Select(CreatePsychologistInfoResponse).ToList();
    }

    public ICollection<PublicPsychologistInfoResponse> GetPsychologistsByPrice(decimal priceMin, decimal priceMax)
    {
        var psychos = _psychologistRepository.GetPsychologistsByPrice(priceMin, priceMax);
        return psychos.Select(CreatePsychologistInfoResponse).ToList();
    }

    public ICollection<PublicPsychologistInfoResponse> GetPsychologistsByRate(float rateMin, float rateMax)
    {
        var psychos = _psychologistRepository.GetPsychologistsByRate(rateMin, rateMax);
        return psychos.Select(CreatePsychologistInfoResponse).ToList();

    }

    private RegistrateUserRequest DtoPsychologistToUser(RegistratePsychologistRequest request)
    {
        return new RegistrateUserRequest(request.FirstName,
            request.LastName, request.Email,
            request.PhoneNumber, request.Password,
            request.Birthday, request.Sex,
            request.AdditionalInfo);
    }

    private UpdateUserRequest DtoUpdatePsychologistToUser(UpdatePsychologistRequest request)
    {
        return new UpdateUserRequest(request.FirstName, request.LastName,
            request.PhoneNumber, request.Password,
            request.AdditionalInfo);
    }

    private PublicPsychologistInfoResponse CreatePsychologistInfoResponse(Psychologist psycho)
    {
        return new PublicPsychologistInfoResponse(psycho.User.FirstName, psycho.User.LastName, psycho.User.Email, 
            psycho.User.PhoneNumber, psycho.User.Birthday, psycho.User.Age, psycho.User.AdditionalInfo, 
            psycho.User.RegistrationDate, psycho.Specialization, psycho.ExperienceStartDate, psycho.ExperienceYears, 
            psycho.PricePerHour, psycho.Rate);
    }
}