using MediatR;
using MentallHealthSupport.Application.Models.Dto.Psychologist;

namespace MentallHealthSupport.Application.Events.Queries.Psychologist;

public class GetAllPsychologistsQuery : IRequest<ICollection<PublicPsychologistInfoResponse>>
{
}