#pragma warning disable IDE0008

using MentallHealthSupport.Application.Abstractions.Persistence.Repositories;
using MentallHealthSupport.Application.Models.Entities;
using MentallHealthSupport.Infrastructure.Persistence.Contexts;
using MentallHealthSupport.Infrastructure.Persistence.Mapping;
using MentallHealthSupport.Infrastructure.Persistence.Models;
using Microsoft.EntityFrameworkCore;

namespace MentallHealthSupport.Infrastructure.Persistence.Repositories;

public class ReviewRepository(ApplicationDbContext dbContext) : IReviewRepository
{
    public async Task CreateReview(Review review)
    {
        var reviewModel = MapToModel(review);
        await dbContext.AddAsync(reviewModel);
        await dbContext.SaveChangesAsync();
    }

    public async Task<Review> GetReviewById(Guid id)
    {
        var reviewModel = await dbContext.Reviews.FirstOrDefaultAsync(review => review.Id == id);
        if (reviewModel == null)
        {
            throw new Exception("No reviews found");
        }

        return MapToEntity(reviewModel);
    }

    public async Task UpdateReview(Review newReview)
    {
        var newReviewModel = MapToModel(newReview);
        var currReview = await dbContext.Reviews.FindAsync(newReview.Id);
        dbContext.Entry(currReview!).CurrentValues.SetValues(newReviewModel);
        await dbContext.SaveChangesAsync();
    }

    public async Task DeleteReview(Guid id)
    {
        var currReview = await dbContext.Reviews.FindAsync(id);
        if (currReview == null)
        {
            throw new Exception("No reviews found");
        }

        dbContext.Reviews.Remove(currReview);
        await dbContext.SaveChangesAsync();
    }

    public ICollection<Review> GetAllReviews(Guid psychoId)
    {
        ICollection<Review> reviews = dbContext.Reviews.Select(MapToEntity).Where(review => review.Psychologist.Id == psychoId).ToList();
        return reviews;
    }

    private Review MapToEntity(ReviewModel model)
    {
        return ReviewMapper.ToEntity(model);
    }

    private ReviewModel MapToModel(Review entity)
    {
        return ReviewMapper.ToModel(entity);
    }
}