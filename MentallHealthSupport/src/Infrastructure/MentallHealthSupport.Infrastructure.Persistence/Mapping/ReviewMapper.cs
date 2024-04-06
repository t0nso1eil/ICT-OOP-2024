using MentallHealthSupport.Application.Models.Entities;
using MentallHealthSupport.Infrastructure.Persistence.Contexts;
using MentallHealthSupport.Infrastructure.Persistence.Models;
using Microsoft.EntityFrameworkCore;

namespace MentallHealthSupport.Infrastructure.Persistence.Mapping;

public class ReviewMapper(ApplicationDbContext dbContext)
{
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

    public async Task<Review> ToEntity(ReviewModel model)
    {
        var psychoMapper = new PsychologistMapper(dbContext);
        return new Review
        {
            Id = model.Id,
            Description = model.Description,
            PostTime = model.PostTime,
            Rate = model.Rate,
            User = UserMapper.ToEntity(await GetUser(model.UserId)),
            Psychologist = await psychoMapper.ToEntity(await GetPsycho(model.PsychologistId)),
        };
    }

    private async Task<UserModel> GetUser(Guid userId)
    {
        var user = await dbContext.Users.FirstOrDefaultAsync(u => u.Id == userId);
        if (user == null)
        {
            throw new Exception();
        }

        return user;
    }

    private async Task<PsychologistModel> GetPsycho(Guid psychoId)
    {
        var user = await dbContext.Psychologists.FirstOrDefaultAsync(u => u.Id == psychoId);
        if (user == null)
        {
            throw new Exception();
        }

        return user;
    }
}