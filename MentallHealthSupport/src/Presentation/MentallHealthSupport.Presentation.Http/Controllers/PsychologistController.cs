#pragma warning disable SA1024
#pragma warning disable SA1028
#pragma warning disable SA1508
#pragma warning disable CS1998
#pragma warning disable IDE0008

using MediatR;
using MentallHealthSupport.Application.Events.Commands.Psychologist;
using MentallHealthSupport.Application.Events.Queries.Psychologist;
using MentallHealthSupport.Application.Exceptions;
using MentallHealthSupport.Application.Models.Dto.Psychologist;
using Microsoft.AspNetCore.Mvc;

namespace MentallHealthSupport.Presentation.Http.Controllers;

[ApiController]
[Route("[controller]")]
public class PsychologistController(IMediator mediator) : ControllerBase
{
    [HttpGet("{id}")]
    public async Task<IActionResult> GetPsychologist(Guid id)
    {
        try
        {
            var query = new GetPsychologistQuery(id);
            var psychoInfo = await mediator.Send(query);
            return Ok(psychoInfo);
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
            var command = new UpdatePsychologistCommand(id, updatePsychologistRequest);
            var updatedPsychoInfo = await mediator.Send(command);
            return Ok(updatedPsychoInfo);
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
            var psychosQuery = new GetAllPsychologistsQuery();
            var psychos = mediator.Send(psychosQuery);
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
    
    [HttpGet("/by-price")]
    public async Task<IActionResult> GetPsychologistsByPrice([FromQuery] decimal priceMin, [FromQuery] decimal priceMax)
    {
        try
        {
            var psychosQuery = new GetPsychologistsByPriceQuery(priceMin, priceMax);
            var psychos = mediator.Send(psychosQuery);
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
    
    [HttpGet("/by-rate")]
    public async Task<IActionResult> GetPsychologistByRate([FromQuery] float rateMin, [FromQuery] float rateMax)
    {
        try
        {
            var psychosQuery = new GetPsychologistsByRateQuery(rateMin, rateMax);
            var psychos = mediator.Send(psychosQuery);
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