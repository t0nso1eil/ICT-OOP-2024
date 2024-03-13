using MentallHealthSupport.Application.Contracts.Services;
using MentallHealthSupport.Application.Models.Dto;
using Microsoft.AspNetCore.Mvc;

namespace MentallHealthSupport.Presentation.Http.Controllers;
[Route("[controller]/users")]
public class AuthController(IUserService userService) : ControllerBase
{
    private readonly IUserService _userService = userService;

    public async Task Login([FromBody] LoginRequest loginRequest)
    {
        var token = await _userService.Login(loginRequest);
        HttpContext.Response.Cookies.Append("coo-coo", token);
    }

    public async Task RegistrateAsUser([FromBody] RegistrateUserRequest request)
    {
        await _userService.CreateUser(request);
    }

    public Task RegistrateAsPsycho([FromBody] RegistratePsychologistRequest request)
    {
        throw new NotImplementedException();
    }
}