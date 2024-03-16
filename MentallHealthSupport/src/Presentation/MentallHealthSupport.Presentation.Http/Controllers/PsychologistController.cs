#pragma warning disable SA1024
#pragma warning disable SA1028
#pragma warning disable SA1508

using MentallHealthSupport.Application.Contracts.Services;
using MentallHealthSupport.Application.Models.Dto;
using Microsoft.AspNetCore.Mvc;

namespace MentallHealthSupport.Presentation.Http.Controllers;

[Route("[controller]/psychologists")]

public class PsychologistController: ControllerBase
{
    private readonly IPsychologistService _psychologistService;

    public PsychologistController(IPsychologistService psychologistService)
    {
        _psychologistService = psychologistService;
    }
    
    [HttpGet]
    public Task<PublicPsychologistInfoResponse> GetPsychologist(Guid id)
    {
        return _psychologistService.GetPsychologist(id);
    }

    [HttpPatch]
    public Task UpdatePsychologist(Guid id, [FromBody] UpdatePsychologistRequest updatePsychologistRequest)
    {
        return _psychologistService.UpdatePsychologist(id, updatePsychologistRequest);
    }
    
    [HttpGet("/users")]
    public ICollection<PublicPsychologistInfoResponse> GetAllPsychologists()
    {
        return _psychologistService.GetAllPsychologists();
    }
    
    [HttpGet("/byPrice")]
    public ICollection<PublicPsychologistInfoResponse> GetPsychologistsByPrice([FromQuery] decimal priceMin, [FromQuery] decimal priceMax)
    {
        return _psychologistService.GetPsychologistsByPrice(priceMin, priceMax);
    }
    
    [HttpGet("/byRate")]
    public ICollection<PublicPsychologistInfoResponse> GetPsychologistByRate([FromQuery] float rateMin, [FromQuery] float rateMax)
    {
        return _psychologistService.GetPsychologistsByRate(rateMin, rateMax);
    }
    
}