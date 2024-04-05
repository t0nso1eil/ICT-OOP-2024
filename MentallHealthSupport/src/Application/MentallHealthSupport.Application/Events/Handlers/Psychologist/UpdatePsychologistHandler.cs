#pragma warning disable IDE0008

using MediatR;
using MentallHealthSupport.Application.Abstractions.Persistence.Repositories;
using MentallHealthSupport.Application.Contracts.Services;
using MentallHealthSupport.Application.Events.Commands.Psychologist;
using MentallHealthSupport.Application.Models.Dto.Psychologist;

namespace MentallHealthSupport.Application.Events.Handlers.Psychologist;
public class UpdatePsychologistHandler : IRequestHandler<UpdatePsychologistCommand, PublicPsychologistInfoResponse>
{
    private readonly IUserRepository _userRepository;
    private readonly IPsychologistRepository _psychologistRepository;
    private readonly IUserService _userService;

    public UpdatePsychologistHandler(IUserRepository userRepository, IPsychologistRepository psychologistRepository, IUserService userService)
    {
        _userRepository = userRepository;
        _psychologistRepository = psychologistRepository;
        _userService = userService;
    }

    public async Task<PublicPsychologistInfoResponse> Handle(UpdatePsychologistCommand request, CancellationToken cancellationToken)
    {
        var psychologist = await _psychologistRepository.GetPsychologistById(request.PsychologistId);
        var user = await _userRepository.GetUserById(psychologist.User.Id);
        var userInfo = request.UpdatePsychologistRequest.ToUpdateUserRequest();
        await _userService.UpdateUser(user.Id, userInfo);

        psychologist.Specialization = request.UpdatePsychologistRequest.Specialization ?? psychologist.Specialization;
        psychologist.PricePerHour = request.UpdatePsychologistRequest.PricePerHour ?? psychologist.PricePerHour;
        await _psychologistRepository.UpdatePsychologist(psychologist);

        psychologist = await _psychologistRepository.GetPsychologistById(request.PsychologistId);
        return PublicPsychologistInfoResponse.FromPsychologist(psychologist);
    }
}