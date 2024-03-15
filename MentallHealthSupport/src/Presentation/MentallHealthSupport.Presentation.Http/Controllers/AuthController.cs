using MentallHealthSupport.Application.Contracts.Services;
using MentallHealthSupport.Application.Models.Dto;
using Microsoft.AspNetCore.Mvc;

namespace MentallHealthSupport.Presentation.Http.Controllers;
[Route("[controller]/users")]
public class AuthController(IUserService userService, IPsychologistService psychologistService) : ControllerBase
{
    private readonly IUserService _userService = userService;
    private readonly IPsychologistService _psychologistService = psychologistService;

    [HttpPost("/login")]
    public async Task Login([FromBody] LoginRequest loginRequest)
    {
        var token = await _userService.Login(loginRequest);

        // HttpContext.Response.Cookies.Append("coo-coo", token);
    }

    [HttpPost("/reg_user")]
    public async Task RegistrateAsUser([FromBody] RegistrateUserRequest request)
    {
        await _userService.CreateUser(request);
    }

    [HttpPost("/reg_psycho")]
    public async Task RegistrateAsPsycho([FromBody] RegistratePsychologistRequest request)
    {
        await _psychologistService.CreatePsychologist(request);
    }
}