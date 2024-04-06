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
    
    public async Task CreatePsychologist(Psychologist psychologist)
    {
        var psychologistModel = MapToModel(psychologist);
        await _dbContext.AddAsync(psychologistModel);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<Psychologist> GetPsychologistById(Guid id)
    {
        var psychologistModel = await _dbContext.Psychologists.FirstOrDefaultAsync(psycho => psycho.Id == id);
        if (psychologistModel == null)
        {
            throw new NotFoundException("No such psychologist.");
        }

        var userModel = await _dbContext.Users.FirstOrDefaultAsync(user => user.Id == psychologistModel.UserId);

        if (userModel == null)
        {
            throw new NotFoundException("No such user.");
        }

        return await MapToEntity(psychologistModel);
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
        var psychologists = await _dbContext.Psychologists.ToListAsync();
        var tasks = psychologists.Select(async p => await GetPsychologistById(p.Id));
        var psychologistsList = await Task.WhenAll(tasks);
        return psychologistsList.ToList();
    }

    public async Task<ICollection<Psychologist>> GetPsychologistsByPrice(decimal priceMin, decimal priceMax)
    {
        var psychologists = await _dbContext.Psychologists
            .Where(p => p.PricePerHour > priceMin && p.PricePerHour < priceMax)
            .ToListAsync();
        var tasks = psychologists.Select(async p => await GetPsychologistById(p.Id));
        var psychologistsList = await Task.WhenAll(tasks);
        return psychologistsList.ToList();
    }

    public async Task<ICollection<Psychologist>> GetPsychologistsByRate(float rateMin, float rateMax)
    {
        var psychologists = await _dbContext.Psychologists
            .Where(p => p.Rate > rateMin && p.Rate < rateMax)
            .ToListAsync();
        var tasks = psychologists.Select(async p => await GetPsychologistById(p.Id));
        var psychologistsList = await Task.WhenAll(tasks);
        return psychologistsList.ToList();
    }

    private async Task<Psychologist> MapToEntity(PsychologistModel model)
    {
        return await _mapper.ToEntity(model);
    }

    private PsychologistModel MapToModel(Psychologist entity)
    {
        return _mapper.ToModel(entity);
    }
}