#pragma warning disable IDE0008
#pragma warning disable SA1028
#pragma warning disable SA1507
#pragma warning disable SA1210
#pragma warning disable SA1025
#pragma warning disable CS1989
#pragma warning disable IDE0007

using MentallHealthSupport.Application.Abstractions.Persistence.Repositories;
using MentallHealthSupport.Application.Exceptions;
using MentallHealthSupport.Application.Models.Entities;
using MentallHealthSupport.Infrastructure.Persistence.Contexts;
using MentallHealthSupport.Infrastructure.Persistence.Mapping;
using MentallHealthSupport.Infrastructure.Persistence.Models;
using Microsoft.EntityFrameworkCore;

namespace MentallHealthSupport.Infrastructure.Persistence.Repositories;
public class PsychologistRepository : IPsychologistRepository
{
    private readonly ApplicationDbContext _dbContext;
    private readonly PsychologistMapper _mapper;

    public PsychologistRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
        _mapper = new PsychologistMapper(_dbContext);
    }
    
    public async Task<Guid> CreatePsychologist(Psychologist psychologist)
    {
        var psychologistModel = MapToModel(psychologist);
        await _dbContext.AddAsync(psychologistModel);
        await _dbContext.SaveChangesAsync();
        return psychologistModel.Id;
    }

    public async Task<Psychologist> GetPsychologistById(Guid id)
    {
        var psychologistModel = await _dbContext.Psychologists.FirstOrDefaultAsync(psycho => psycho.Id == id);
        if (psychologistModel == null)
        {
            throw new NotFoundException("No such psychologist.");
        }

        return await _mapper.ToEntity(psychologistModel);
    }


    public async Task UpdatePsychologist(Psychologist newPsychologist)
    {
        var newPsychologistModel = MapToModel(newPsychologist);
        var currPsychologist = await _dbContext.Psychologists.FindAsync(newPsychologistModel.Id);
        _dbContext.Entry(currPsychologist!).CurrentValues.SetValues(newPsychologistModel);
        await _dbContext.SaveChangesAsync();
    }
    
    
    public async Task<ICollection<Psychologist>> GetAllPsychologists()
    {
        var psychologists = _dbContext.Psychologists.ToList();
        var res = new List<Psychologist>();
        foreach (var p in psychologists)
        {
            var temp = await _mapper.ToEntity(p);
            res.Add(temp);
        }

        return res;
    }

    public async Task<ICollection<Psychologist>> GetPsychologistsByPrice(decimal priceMin, decimal priceMax)
    {
        var psychologists = _dbContext.Psychologists
            .Where(p => p.PricePerHour > priceMin && p.PricePerHour < priceMax)
            .AsEnumerable();
        var res = new List<Psychologist>();
        foreach (var p in psychologists)
        {
            var temp = await _mapper.ToEntity(p);
            res.Add(temp);
        }

        return res;
    }

    public async Task<ICollection<Psychologist>> GetPsychologistsByRate(float rateMin, float rateMax)
    {
        var psychologists = _dbContext.Psychologists
            .Where(p => p.Rate > rateMin && p.Rate < rateMax)
            .AsEnumerable();
        var res = new List<Psychologist>();
        foreach (var p in psychologists)
        {
            var temp = await _mapper.ToEntity(p);
            res.Add(temp);
        }

        return res;
    }

    private PsychologistModel MapToModel(Psychologist entity)
    {
        return _mapper.ToModel(entity);
    }
}