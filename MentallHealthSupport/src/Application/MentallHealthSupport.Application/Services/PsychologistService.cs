using MentallHealthSupport.Application.Abstractions.Persistence.Repositories;
using MentallHealthSupport.Application.Contracts.Services;
using MentallHealthSupport.Application.Models.Dto;
using MentallHealthSupport.Application.Models.Entities;
using MentallHealthSupport.Application.Services.Auth;
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
    
    public async Task CreatePsychologist(RegistratePsychologistRequest registratePsychologistRequest)
    {
        var userInfo = new RegistrateUserRequest(registratePsychologistRequest.FirstName,
            registratePsychologistRequest.LastName, registratePsychologistRequest.Email,
            registratePsychologistRequest.PhoneNumber, registratePsychologistRequest.Password,
            registratePsychologistRequest.Birthday, registratePsychologistRequest.Sex,
            registratePsychologistRequest.AdditionalInfo);

        await _userService.CreateUser(userInfo);

        var user = (await _userRepository.GetUserByEmail(registratePsychologistRequest.Email))!; // не нравится
        user.IsPsychologist = true;

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
    }
    

    public async Task<PublicPsychologistInfoResponse> GetPsychologist(Guid psychologistId)
    {
        var psycho = await _psychologistRepository.GetPsychologistById(psychologistId);
        return new PublicPsychologistInfoResponse(psycho.User.FirstName, psycho.User.LastName, psycho.User.Email, 
            psycho.User.PhoneNumber, psycho.User.Birthday, psycho.User.Age, psycho.User.AdditionalInfo, 
            psycho.User.RegistrationDate, psycho.Specialization, psycho.ExperienceStartDate, psycho.ExperienceYears, 
            psycho.PricePerHour, psycho.Rate);

    }

    public async Task UpdatePsychologist(Guid psychologistId, UpdatePsychologistRequest updatePsychologistRequest)
    {
        var psycho = await _psychologistRepository.GetPsychologistById(psychologistId);
        var user = await _userRepository.GetUserById(psycho.User.Id);
        var userInfo = new UpdateUserRequest(updatePsychologistRequest.FirstName, updatePsychologistRequest.LastName,
            updatePsychologistRequest.PhoneNumber, updatePsychologistRequest.Password,
            updatePsychologistRequest.AdditionalInfo);
        await _userService.UpdateUser(user.Id, userInfo);
        
        psycho.Specialization = updatePsychologistRequest.Specialization ?? psycho.Specialization;
        psycho.PricePerHour = updatePsychologistRequest.PricePerHour ?? psycho.PricePerHour;
        await _psychologistRepository.UpdatePsychologist(psycho);
    }

    public ICollection<PublicPsychologistInfoResponse> GetAllPsychologists()
    {
        var psychos = _psychologistRepository.GetAllPsychologists();
        return psychos.Select(psycho => new PublicPsychologistInfoResponse(psycho.User.FirstName, 
            psycho.User.LastName, psycho.User.Email, psycho.User.PhoneNumber, psycho.User.Birthday, 
            psycho.User.Age, psycho.User.AdditionalInfo, psycho.User.RegistrationDate, psycho.Specialization, 
            psycho.ExperienceStartDate, psycho.ExperienceYears, psycho.PricePerHour, psycho.Rate)).ToList();
    }

    public ICollection<PublicPsychologistInfoResponse> GetPsychologistsByPrice(decimal priceMin, decimal priceMax)
    {
        var psychos = _psychologistRepository.GetPsychologistsByPrice(priceMin, priceMax);
        return psychos.Select(psycho => new PublicPsychologistInfoResponse(psycho.User.FirstName, 
            psycho.User.LastName, psycho.User.Email, psycho.User.PhoneNumber, psycho.User.Birthday, 
            psycho.User.Age, psycho.User.AdditionalInfo, psycho.User.RegistrationDate, psycho.Specialization, 
            psycho.ExperienceStartDate, psycho.ExperienceYears, psycho.PricePerHour, psycho.Rate)).ToList();
    }

    public ICollection<PublicPsychologistInfoResponse> GetPsychologistsByRate(float rateMin, float rateMax)
    {
        var psychos = _psychologistRepository.GetPsychologistsByRate(rateMin, rateMax);
        return psychos.Select(psycho => new PublicPsychologistInfoResponse(psycho.User.FirstName, 
            psycho.User.LastName, psycho.User.Email, psycho.User.PhoneNumber, psycho.User.Birthday, 
            psycho.User.Age, psycho.User.AdditionalInfo, psycho.User.RegistrationDate, psycho.Specialization, 
            psycho.ExperienceStartDate, psycho.ExperienceYears, psycho.PricePerHour, psycho.Rate)).ToList();

    }
}