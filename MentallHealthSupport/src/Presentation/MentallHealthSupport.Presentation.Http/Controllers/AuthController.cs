#pragma warning disable IDE0008
#pragma warning disable SA1028

using MentallHealthSupport.Application.Contracts.Services;
using MentallHealthSupport.Application.Exceptions;
using MentallHealthSupport.Application.Models.Dto.Psychologist;
using MentallHealthSupport.Application.Models.Dto.User;
using Microsoft.AspNetCore.Mvc;

namespace MentallHealthSupport.Presentation.Http.Controllers;
[Route("[controller]/users")]
public class AuthController(IUserService userService, IPsychologistService psychologistService) : ControllerBase
{
    private readonly IUserService _userService = userService;
    private readonly IPsychologistService _psychologistService = psychologistService;

    [HttpPost]
    public async Task Login([FromBody] LoginRequest loginRequest)
    {
        var token = await _userService.Login(loginRequest);
        HttpContext.Response.Cookies.Append("coo-coo", token);
    }

    [HttpPost("/reg_user")]
    public async Task<IActionResult> RegistrateAsUser([FromBody] RegistrateUserRequest request)
    {
        try
        {
            var userId = await _userService.CreateUser(request);
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
    
    [HttpPost("/reg_psycho")]
    public async Task RegistrateAsPsycho([FromBody] RegistratePsychologistRequest request)
    {
        await _psychologistService.CreatePsychologist(request);
    }
}