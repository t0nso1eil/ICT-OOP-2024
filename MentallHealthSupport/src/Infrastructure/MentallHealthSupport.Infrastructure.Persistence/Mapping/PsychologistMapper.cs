#pragma warning disable IDE0005
#pragma warning disable IDE0008
#pragma warning disable SA1028
#pragma warning disable SA1507

using MentallHealthSupport.Application.Models.Entities;
using MentallHealthSupport.Infrastructure.Persistence.Models;

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
        foreach (var spot in spots)
        {
            psycho.Spots.Add(spot);
        }

        return psycho;
    }

    public static PsychologistModel ToModel(Psychologist psychologist)
    {
        var psychoModel = new PsychologistModel()
        {
            Id = psychologist.Id,
            User = UserMapper.ToModel(psychologist.User),
            Specialization = psychologist.Specialization,
            ExperienceStartDate = psychologist.ExperienceStartDate,
            ExperienceYears = psychologist.ExperienceYears,
            PricePerHour = psychologist.PricePerHour,
            Rate = psychologist.Rate,
        };
        

        ICollection<SpotModel> spots = psychologist.Spots.Select(SpotMapper.ToModel).ToList();
        foreach (var spot in spots)
        {
            psychoModel.Spots.Add(spot);
        }

        ICollection<ReviewModel> reviews = psychologist.Reviews.Select(ReviewMapper.ToModel).ToList();
        foreach (var spot in spots)
        {
            psychoModel.Spots.Add(spot);
        }

        return psychoModel;
    }
}
