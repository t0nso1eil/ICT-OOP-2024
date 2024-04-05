#pragma warning disable IDE0008

using MediatR;
using MentallHealthSupport.Application.Abstractions.Persistence.Repositories;
using MentallHealthSupport.Application.Contracts.Services;
using MentallHealthSupport.Application.Events.Commands.User;

namespace MentallHealthSupport.Application.Events.Handlers.Psychologist;

public class CreatePsychologistHandler : IRequestHandler<CreatePsychologistCommand, Guid>
{
    private readonly IUserService _userService;
    private readonly IUserRepository _userRepository;
    private readonly IPsychologistRepository _psychologistRepository;

    public CreatePsychologistHandler(IUserService userService, IUserRepository userRepository, IPsychologistRepository psychologistRepository)
    {
        _userService = userService;
        _userRepository = userRepository;
        _psychologistRepository = psychologistRepository;
    }

    public async Task<Guid> Handle(CreatePsychologistCommand request, CancellationToken cancellationToken)
    {
        var userInfo = request.RegistratePsychologistRequest.ToRegistrateUserRequest();

        Guid id = await _userService.CreateUser(userInfo);
        await _userRepository.UpdateStatus(id, true);
        var user = await _userRepository.GetUserById(id);
        var psycho = new Models.Entities.Psychologist
        {
            Id = Guid.NewGuid(),
            User = user,
            Specialization = request.RegistratePsychologistRequest.Specialization,
            ExperienceStartDate = request.RegistratePsychologistRequest.ExperienceStartDate,
            ExperienceYears = (uint)(DateTime.Today.Year - request.RegistratePsychologistRequest.ExperienceStartDate.Year),
            PricePerHour = request.RegistratePsychologistRequest.PricePerHour,
        };

        await _psychologistRepository.CreatePsychologist(psycho);
        return psycho.Id;
    }
}