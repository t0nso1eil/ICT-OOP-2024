#pragma warning disable IDE0008
#pragma warning disable SA1028

using MediatR;
using MentallHealthSupport.Application.Events.Commands.User;
using MentallHealthSupport.Application.Exceptions;
using MentallHealthSupport.Application.Models.Dto.User;
using Microsoft.AspNetCore.Mvc;

namespace MentallHealthSupport.Presentation.Http.Controllers;
[Route("[controller]")]
public class AuthController(IMediator mediator) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Login([FromBody] LoginRequest loginRequest)
    {
        try
        {
            var token = await mediator.Send(new LoginCommand(loginRequest));
            return Ok(new { token });
        }
        catch (NotFoundException ex)
        {
            return NotFound(ex.Message);
        }
        catch (IncorrectInputException ex)
        {
            return BadRequest(ex.Message);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { Error = ex.Message });
        }
    }

    [HttpPost("/reg-user")]
    public async Task<IActionResult> RegistrateAsUser([FromBody] RegistrateUserRequest request)
    {
        try
        {
            var command = new CreateUserCommand(request);
            var userId = await mediator.Send(command);
            return Ok(new { UserId = userId });
        }
        catch (ConflictException ex)
        {
            return Conflict(new { Error = ex.Message });
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
    
    // [HttpPost("/reg-psycho")]
    // public async Task<IActionResult> RegistrateAsPsycho([FromBody] RegistratePsychologistRequest request)
    // {
    //     try
    //     {
    //         var psychoId = await _psychologistService.CreatePsychologist(request);
    //         return Ok(new { PsychologistId = psychoId });
    //     }
    //     catch (ConflictException ex)
    //     {
    //         return Conflict(new { Error = ex.Message });
    //     }
    //     catch (IncorrectInputException ex)
    //     {
    //         return BadRequest(new { Error = ex.Message });
    //     }
    //     catch (Exception ex)
    //     {
    //         return StatusCode(500, new { Error = ex.Message });
    //     }
    // }
}