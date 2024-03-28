#pragma warning disable IDE0005
#pragma warning disable IDE0008
#pragma warning disable SA1028
#pragma warning disable SA1507
#pragma warning disable IDE0007

using MentallHealthSupport.Application.Exceptions;
using MentallHealthSupport.Application.Models.Entities;
using MentallHealthSupport.Infrastructure.Persistence.Contexts;
using MentallHealthSupport.Infrastructure.Persistence.Models;
using Microsoft.EntityFrameworkCore;

namespace MentallHealthSupport.Infrastructure.Persistence.Mapping;
public class PsychologistMapper()
{
    public PsychologistModel ToModel(Psychologist psychologist)
    {
        var psychoModel = new PsychologistModel
        {
            Id = psychologist.Id,
            Specialization = psychologist.Specialization,
            ExperienceStartDate = psychologist.ExperienceStartDate,
            ExperienceYears = psychologist.ExperienceYears,
            PricePerHour = psychologist.PricePerHour,
            Rate = psychologist.Rate,
            UserId = psychologist.User.Id,
        };
        return psychoModel;
    }
    
    public Psychologist ToEntity(PsychologistModel psychologistModel, UserModel userModel)
    {
        if (userModel == null)
        {
            throw new NotFoundException("No such user");
        }

        var psycho = new Psychologist
        {
            Id = psychologistModel.Id,
            Specialization = psychologistModel.Specialization,
            ExperienceStartDate = psychologistModel.ExperienceStartDate,
            ExperienceYears = psychologistModel.ExperienceYears,
            PricePerHour = psychologistModel.PricePerHour,
            Rate = psychologistModel.Rate,
            User = UserMapper.ToEntity(userModel),
        };
        return psycho;
    }
}
