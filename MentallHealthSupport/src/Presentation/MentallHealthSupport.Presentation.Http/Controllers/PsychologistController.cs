#pragma warning disable SA1024
#pragma warning disable SA1028
#pragma warning disable SA1508
#pragma warning disable CS1998

using MentallHealthSupport.Application.Contracts.Services;
using MentallHealthSupport.Application.Exceptions;
using MentallHealthSupport.Application.Models.Dto.Psychologist;
using Microsoft.AspNetCore.Mvc;

namespace MentallHealthSupport.Presentation.Http.Controllers;

[Route("[controller]")]

public class PsychologistController: ControllerBase
{
    private readonly IPsychologistService _psychologistService;

    public PsychologistController(IPsychologistService psychologistService)
    {
        _psychologistService = psychologistService;
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetPsychologist(Guid id)
    {
        try
        {
            var psycho = await _psychologistService.GetPsychologist(id);
            return Ok(new { Psychologist = psycho });
        }
        catch (NotFoundException ex)
        {
            return NotFound(new { Error = ex.Message });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { Error = ex.Message });
        }
    }

    [HttpPatch("{id}")]
    public async Task<IActionResult> UpdatePsychologist(Guid id, [FromBody] UpdatePsychologistRequest updatePsychologistRequest)
    {
        try
        {
            var psycho = await _psychologistService.UpdatePsychologist(id, updatePsychologistRequest);
            return Ok(psycho);
        }
        catch (NotFoundException ex)
        {
            return NotFound(new { Error = ex.Message });
        }
        catch (IncorrectInputException ex)
        {
            return BadRequest(new { Error = ex.Message });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { Error = ex.Message });
        }
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAllPsychologists()
    {
        try
        {
            var psychos = _psychologistService.GetAllPsychologists();
            return Ok(psychos);
        }
        catch (NotFoundException ex)
        {
            return NotFound(new { Error = ex.Message });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { Error = ex.Message });
        }
    }
    
    [HttpGet("/byPrice")]
    public async Task<IActionResult> GetPsychologistsByPrice([FromQuery] decimal priceMin, [FromQuery] decimal priceMax)
    {
        try
        {
            var psychos = _psychologistService.GetPsychologistsByPrice(priceMin, priceMax);
            return Ok(psychos);
        }
        catch (NotFoundException ex)
        {
            return NotFound(new { Error = ex.Message });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { Error = ex.Message });
        }
    }
    
    [HttpGet("/byRate")]
    public async Task<IActionResult> GetPsychologistByRate([FromQuery] float rateMin, [FromQuery] float rateMax)
    {
        try
        {
            var psychos = _psychologistService.GetPsychologistsByRate(rateMin, rateMax);
            return Ok(psychos);
        }
        catch (NotFoundException ex)
        {
            return NotFound(new { Error = ex.Message });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { Error = ex.Message });
        }
    }
    
}