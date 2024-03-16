using MentallHealthSupport.Application.Models.Entities;
using MentallHealthSupport.Infrastructure.Persistence.Models;

namespace MentallHealthSupport.Infrastructure.Persistence.Mapping;

public class ReviewMapper
{
    public static Review ToEntity(ReviewModel reviewModel)
    {
        return new Review
        {
            Id = reviewModel.Id,
            //User = UserMapper.ToEntity(reviewModel.User),
            Rate = reviewModel.Rate,
            Description = reviewModel.Description,
        };
    }

    public static ReviewModel ToModel(Review review)
    {
        return new ReviewModel
        {
            Id = review.Id,
            //User = UserMapper.ToModel(review.User),
            Rate = review.Rate,
            Description = review.Description,
        };
    }
}