#pragma warning disable IDE0008
#pragma warning disable SA1028
#pragma warning disable SA1507
#pragma warning disable SA1210
#pragma warning disable SA1025
#pragma warning disable CS1989
#pragma warning disable IDE0007

using MentallHealthSupport.Application.Abstractions.Persistence.Repositories;
using MentallHealthSupport.Application.Models.Entities;
using MentallHealthSupport.Infrastructure.Persistence.Contexts;
using MentallHealthSupport.Infrastructure.Persistence.Mapping;
using MentallHealthSupport.Infrastructure.Persistence.Models;
using Microsoft.EntityFrameworkCore;

namespace MentallHealthSupport.Infrastructure.Persistence.Repositories;
public class PsychologistRepository(ApplicationDbContext dbContext, PsychologistMapper mapper) : IPsychologistRepository
{
    public async Task CreatePsychologist(Psychologist psychologist)
    {
        var psychologistModel = MapToModel(psychologist);
        await dbContext.AddAsync(psychologistModel);
        await dbContext.SaveChangesAsync();
    }

    public async Task<Psychologist> GetPsychologistById(Guid id)
    {
        var psychologistModel = await dbContext.Psychologists.FirstOrDefaultAsync(psycho => psycho.Id == id);
        if (psychologistModel == null)
        {
            throw new Exception("такого нет");
        }

        var userModel = await dbContext.Users.FirstOrDefaultAsync(user => user.Id == psychologistModel.UserId);

        if (userModel == null)
        {
            throw new Exception("Данные пользователя не найдены");
        }

        return MapToEntity(psychologistModel, userModel);
    }


    public async Task UpdatePsychologist(Psychologist newPsychologist)
    {
        var newPsychologistModel = MapToModel(newPsychologist);
        var currPsychologist = await dbContext.Psychologists.FindAsync(newPsychologistModel.Id);
        dbContext.Entry(currPsychologist!).CurrentValues.SetValues(newPsychologistModel);
        await dbContext.SaveChangesAsync();
    }
    
    
    public ICollection<Task<Psychologist>> GetAllPsychologists()
    {
        var psychologistTasks = dbContext.Psychologists
            .Select(p => GetPsychologistById(p.Id))
            .ToList();
        return psychologistTasks;
    }

    public ICollection<Task<Psychologist>> GetPsychologistsByPrice(decimal priceMin, decimal priceMax)
    {
        ICollection<Task<Psychologist>> psychologists = dbContext.Psychologists
            .Where(p => p.PricePerHour > priceMin && p.PricePerHour < priceMax)
            .AsEnumerable()
            .Select(p =>  GetPsychologistById(p.Id))
            .ToList();
        return psychologists;
    }

    public ICollection<Task<Psychologist>> GetPsychologistsByRate(float rateMin, float rateMax)
    {
        ICollection<Task<Psychologist>> psychologists = dbContext.Psychologists
            .Where(p => p.Rate > rateMin && p.Rate < rateMax)
            .AsEnumerable()
            .Select(p => GetPsychologistById(p.Id))
            .ToList();
        return psychologists;
    }

    private Psychologist MapToEntity(PsychologistModel model, UserModel user)
    {
        return mapper.ToEntity(model, user);
    }

    private PsychologistModel MapToModel(Psychologist entity)
    {
        return mapper.ToModel(entity);
    }
}