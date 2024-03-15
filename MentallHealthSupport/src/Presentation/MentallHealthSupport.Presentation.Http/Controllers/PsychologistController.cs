using MentallHealthSupport.Application.Contracts.Services;
using MentallHealthSupport.Application.Models.Dto;
using Microsoft.AspNetCore.Mvc;

namespace MentallHealthSupport.Presentation.Http.Controllers;

[Route("[controller]/psychologists")]

public class PsychologistController : ControllerBase
{
    private readonly IPsychologistService _psychologistService;

    public PsychologistController(IPsychologistService psychologistService)
    {
        _psychologistService = psychologistService;
    }

    [HttpGet("/{id}")]
    public Task<PublicPsychologistInfoResponse> GetPsychologist(Guid id)
    {
        return _psychologistService.GetPsychologist(id);
    }

    [HttpPatch("/{id}")]
    public Task UpdatePsychologist(Guid id, [FromBody] UpdatePsychologistRequest updatePsychologistRequest)
    {
        return _psychologistService.UpdatePsychologist(id, updatePsychologistRequest);
    }

    [HttpGet]
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