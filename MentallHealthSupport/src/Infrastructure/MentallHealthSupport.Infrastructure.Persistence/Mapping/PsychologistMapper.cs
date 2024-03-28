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
public class PsychologistMapper(ApplicationDbContext dbContext)
{
    public async Task<Psychologist> ToEntity(PsychologistModel psychologistModel)
    {
        var psycho = new Psychologist
        {
            Id = psychologistModel.Id,
            Specialization = psychologistModel.Specialization,
            ExperienceStartDate = psychologistModel.ExperienceStartDate,
            ExperienceYears = psychologistModel.ExperienceYears,
            PricePerHour = psychologistModel.PricePerHour,
            Rate = psychologistModel.Rate, 
            User = UserMapper.ToEntity(await GetUser(psychologistModel.UserId)),
        };
        return psycho;
    }
    
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

    private async Task<UserModel> GetUser(Guid userId)
    {
        var user = await dbContext.Users.FirstOrDefaultAsync(u => u.Id == userId);
        if (user == null)
        {
            throw new Exception();
        }

        return user;
    }
}
