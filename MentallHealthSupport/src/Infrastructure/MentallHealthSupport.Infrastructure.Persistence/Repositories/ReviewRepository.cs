using MentallHealthSupport.Application.Abstractions.Persistence.Repositories;
using MentallHealthSupport.Application.Exceptions;
using MentallHealthSupport.Application.Models.Entities;
using MentallHealthSupport.Infrastructure.Persistence.Contexts;
using MentallHealthSupport.Infrastructure.Persistence.Mapping;
using MentallHealthSupport.Infrastructure.Persistence.Models;
using Microsoft.EntityFrameworkCore;

namespace MentallHealthSupport.Infrastructure.Persistence.Repositories;

public class ReviewRepository(ApplicationDbContext dbContext) : IReviewRepository
{
    private readonly ReviewMapper _mapper = new ReviewMapper(dbContext);

    public async Task<Guid> CreateReview(Review review)
    {
        var reviewModel = MapToModel(review);
        await dbContext.AddAsync(reviewModel);
        await dbContext.SaveChangesAsync();
        return reviewModel.Id;
    }

    public async Task<Review> GetReviewById(Guid id)
    {
        var reviewModel = await dbContext.Reviews.FirstOrDefaultAsync(review => review.Id == id);
        if (reviewModel == null)
        {
            throw new NotFoundException("No reviews found");
        }

        return await MapToEntity(reviewModel);
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
            throw new NotFoundException("No reviews found");
        }

        dbContext.Reviews.Remove(currReview);
        await dbContext.SaveChangesAsync();
    }

    public async Task<ICollection<Review>> GetAllReviews(Guid psychoId)
    {
        var reviews = dbContext.Reviews
            .Where(review => review.PsychologistId == psychoId)
            .AsEnumerable().ToList();
        ICollection<Review> res = new List<Review>();
        foreach (var r in reviews)
        {
            var e = await MapToEntity(r);
            res.Add(e);
        }

        return res;
    }

    private async Task<Review> MapToEntity(ReviewModel model)
    {
        return await _mapper.ToEntity(model);
    }

    private ReviewModel MapToModel(Review entity)
    {
        return ReviewMapper.ToModel(entity);
    }
}