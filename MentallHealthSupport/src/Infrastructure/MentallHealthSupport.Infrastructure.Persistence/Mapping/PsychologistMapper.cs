#pragma warning disable IDE0005
#pragma warning disable IDE0008
#pragma warning disable SA1028
#pragma warning disable SA1507
#pragma warning disable IDE0007

using MentallHealthSupport.Application.Models.Entities;
using MentallHealthSupport.Infrastructure.Persistence.Contexts;
using MentallHealthSupport.Infrastructure.Persistence.Models;
using Microsoft.EntityFrameworkCore;

namespace MentallHealthSupport.Infrastructure.Persistence.Mapping;
public class PsychologistMapper
{
    public static Psychologist ToEntity(PsychologistModel psychologistModel)
    {
        var psycho = new Psychologist
        {
            Id = psychologistModel.Id,
            User = UserMapper.ToEntity(psychologistModel.User),
            Specialization = psychologistModel.Specialization,
            ExperienceStartDate = psychologistModel.ExperienceStartDate,
            ExperienceYears = psychologistModel.ExperienceYears,
            PricePerHour = psychologistModel.PricePerHour,
            Rate = psychologistModel.Rate,
        };
        

        ICollection<Spot> spots = psychologistModel.Spots.Select(SpotMapper.ToEntity).ToList();
        foreach (var spot in spots)
        {
            psycho.Spots.Add(spot);
        }

        ICollection<Review> reviews = psychologistModel.Reviews.Select(ReviewMapper.ToEntity).ToList();
        foreach (var review in reviews)
        {
            psycho.Reviews.Add(review);
        }

        return psycho;
    }

    public static async Task<PsychologistModel> ToModel(Psychologist psychologist, ApplicationDbContext context)
    {
        var psychoModel = new PsychologistModel()
        {
            Id = psychologist.Id,
            User = (await context.Users.FirstOrDefaultAsync(p => p.Id == psychologist.User.Id))!,
            Specialization = psychologist.Specialization,
            ExperienceStartDate = psychologist.ExperienceStartDate,
            ExperienceYears = psychologist.ExperienceYears,
            PricePerHour = psychologist.PricePerHour,
            Rate = psychologist.Rate,
        };
        
    
        List<Task<SpotModel>> spots = psychologist.Spots.Select(async p => await SpotMapper.ToModel(p, context)).ToList();
        foreach (var spot in spots)
        {
            psychoModel.Spots.Add(await spot);
        }

        ICollection<ReviewModel> reviews = psychologist.Reviews.Select(ReviewMapper.ToModel).ToList();
        foreach (var review in reviews)
        {
            psychoModel.Reviews.Add(review);
        }

        return psychoModel;
    }
}
