using MediatR;
using MentallHealthSupport.Application.Abstractions.Persistence.Repositories;
using MentallHealthSupport.Application.Events.Commands.Review;

namespace MentallHealthSupport.Application.Events.Handlers.Review;

public class CreateReviewHandler : IRequestHandler<CreateReviewCommand, Guid>
{
    private readonly IUserRepository _userRepository;
    private readonly IPsychologistRepository _psychologistRepository;
    private readonly IReviewRepository _reviewRepository;

    public CreateReviewHandler(IUserRepository userRepository, IPsychologistRepository psychologistRepository, IReviewRepository reviewRepository)
    {
        _userRepository = userRepository;
        _psychologistRepository = psychologistRepository;
        _reviewRepository = reviewRepository;
    }

    public async Task<Guid> Handle(CreateReviewCommand request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetUserById(request.CreateReviewRequest.UserId);
        var psychologist = await _psychologistRepository.GetPsychologistById(request.CreateReviewRequest.PsychologistId);
        var review = request.CreateReviewRequest.ToReview(user, psychologist);
        return await _reviewRepository.CreateReview(review);
    }
}