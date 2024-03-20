using MentallHealthSupport.Application.Models.Entities;
using MentallHealthSupport.Infrastructure.Persistence.Models;


namespace MentallHealthSupport.Infrastructure.Persistence.Mapping;

public static class ReviewMapper
{
    public static Review ToEntity(ReviewModel reviewModel)
    {
        var review = new Review
        {
            Id = reviewModel.Id,
            //User = UserMapper.ToEntity(reviewModel.User),
            Rate = reviewModel.Rate,
            Description = reviewModel.Description,
        };
        return review;
    }

    public static ReviewModel ToModel(Review review)
    {
        var reviewModel = new ReviewModel
        {
            Id = review.Id,
            //User = UserMapper.ToModel(review.User),
            Rate = review.Rate,
            Description = review.Description,
        };
        return reviewModel;
    }
}