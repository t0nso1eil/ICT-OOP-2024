namespace MentallHealthSupport.Application.Models.Dto.Review;

public record PublicReviewInfoResponse(
    string PsychologistFirstName,
    string PsychologistLastName,
    string UserFirstName,
    string UserLastName,
    uint Rate,
    string Description,
    DateTime PostTime)
{
    public static PublicReviewInfoResponse FromReview(Entities.Review review)
    {
        return new PublicReviewInfoResponse(
            review.Psychologist.User.FirstName,
            review.Psychologist.User.LastName,
            review.User.FirstName,
            review.User.LastName,
            review.Rate,
            review.Description,
            review.PostTime);
    }
}