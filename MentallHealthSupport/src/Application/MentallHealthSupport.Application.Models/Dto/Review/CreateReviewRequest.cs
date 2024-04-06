#pragma warning disable IDE0161
#pragma warning disable SA1129

namespace MentallHealthSupport.Application.Models.Dto.Review
{
    public record CreateReviewRequest(
        Guid UserId,
        Guid PsychologistId,
        uint Rate,
        string Description)
    {
        public Entities.Review CreateReview(Entities.User user, Entities.Psychologist psychologist)
        {
            return new Entities.Review
            {
                Id = new Guid(),
                User = user,
                Psychologist = psychologist,
                Rate = Rate,
                Description = Description,
                PostTime = DateTime.Now,
            };
        }
    }
}