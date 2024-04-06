#pragma warning disable IDE0008

using MediatR;
using MentallHealthSupport.Application.Abstractions.Persistence.Repositories;
using MentallHealthSupport.Application.Contracts.Services;
using MentallHealthSupport.Application.Events.Commands.User;

namespace MentallHealthSupport.Application.Events.Handlers.Psychologist;

public class CreatePsychologistHandler : IRequestHandler<CreatePsychologistCommand, Guid>
{
    private readonly IMediator _mediator;
    private readonly IUserRepository _userRepository;
    private readonly IPsychologistRepository _psychologistRepository;

    public CreatePsychologistHandler( IUserRepository userRepository, IPsychologistRepository psychologistRepository, IMediator mediator)
    {
        _userRepository = userRepository;
        _psychologistRepository = psychologistRepository;
        _mediator = mediator;
    }

    public async Task<Guid> Handle(CreatePsychologistCommand request, CancellationToken cancellationToken)
    {
        var userInfo = request.RegistratePsychologistRequest.ToRegistrateUserRequest();

        var createUserCommand = new CreateUserCommand(userInfo);
        var userId = await _mediator.Send(createUserCommand, cancellationToken);

        var user = await _userRepository.GetUserById(userId);
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