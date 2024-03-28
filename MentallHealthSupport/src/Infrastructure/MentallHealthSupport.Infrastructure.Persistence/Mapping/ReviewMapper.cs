using MentallHealthSupport.Application.Models.Entities;
using MentallHealthSupport.Infrastructure.Persistence.Models;

namespace MentallHealthSupport.Infrastructure.Persistence.Mapping;

public class ReviewMapper
{
    public static Review ToEntity(ReviewModel model)
    {
        return new Review
        {
            Id = model.Id,
            Description = model.Description,
            PostTime = model.PostTime,
            Rate = model.Rate,

            // User + Psychologist
        };
    }

    public static ReviewModel ToModel(Review review)
    {
        return new ReviewModel
        {
            Id = review.Id,
            Description = review.Description,
            PostTime = review.PostTime,
            Rate = review.Rate,
            UserId = review.User.Id,
            PsychologistId = review.Psychologist.Id,
        };
    }
}