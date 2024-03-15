using MentallHealthSupport.Application.Abstractions.Persistence.Repositories;
using MentallHealthSupport.Application.Models.Entities;
using MentallHealthSupport.Infrastructure.Persistence.Contexts;
using MentallHealthSupport.Infrastructure.Persistence.Mapping;
using MentallHealthSupport.Infrastructure.Persistence.Models;
using Microsoft.EntityFrameworkCore;

namespace MentallHealthSupport.Infrastructure.Persistence.Repositories;
public class PsychologistRepository(ApplicationDbContext dbContext) : IPsychologistRepository
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

        return MapToEntity(psychologistModel);
    }

    public async Task UpdatePsychologist(Psychologist newPsychologist)
    {
        var newPsychologistModel = MapToModel(newPsychologist);
        var currPsychologist = await dbContext.Psychologists.FindAsync(newPsychologistModel.Id);
        dbContext.Entry(currPsychologist!).CurrentValues.SetValues(newPsychologistModel);
        await dbContext.SaveChangesAsync();
    }

    public ICollection<Psychologist> GetAllPsychologists()
    {
        ICollection<Psychologist> psychologists = dbContext.Psychologists.Select(PsychologistMapper.ToEntity).ToList();
        return psychologists;
    }

    public ICollection<Psychologist> GetPsychologistsByPrice(decimal priceMin, decimal priceMax)
    {
        ICollection<Psychologist> psychologists = dbContext.Psychologists
            .Where(p => p.PricePerHour > priceMin && p.PricePerHour < priceMax).AsEnumerable()
            .Select(PsychologistMapper.ToEntity)
            .ToList();
        return psychologists;
    }

    public ICollection<Psychologist> GetPsychologistsByRate(float rateMin, float rateMax)
    {
        ICollection<Psychologist> psychologists = dbContext.Psychologists
            .Where(p => p.Rate > rateMin && p.Rate < rateMax).AsEnumerable()
            .Select(PsychologistMapper.ToEntity)
            .ToList();
        return psychologists;
    }

    private Psychologist MapToEntity(PsychologistModel model)
    {
        return PsychologistMapper.ToEntity(model);
    }

    private PsychologistModel MapToModel(Psychologist entity)
    {
        return PsychologistMapper.ToModel(entity);
    }
}