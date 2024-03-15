using MentallHealthSupport.Application.Models.Entities;
using MentallHealthSupport.Infrastructure.Persistence.Models;

namespace MentallHealthSupport.Infrastructure.Persistence.Mapping;

public class ReviewMapper
{
    public static Review ToEntity(ReviewModel model)
    {
        return new Review();
    }

    public static ReviewModel ToModel(Review review)
    {
        return new ReviewModel();
    }
}