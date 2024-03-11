namespace MentallHealthSupport.Presentation.Http.Controllers;

using MentallHealthSupport.Application.Contracts.Services;
using MentallHealthSupport.Application.Models.Dto;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;

[Route("[controller]")]
public class AuthController(IUserService userService) : ControllerBase
{
    private readonly IUserService _userService = userService;

    public async Task Login([FromBody] LoginRequest loginRequest)
    {
        var token = await _userService.Login(loginRequest);
        HttpContext.Response.Cookies.Append("coo-coo", token);
    }

    public Task RegistrateAsUser([FromBody] RegistrateUserRequest registrateUserRequest)
    {
        throw new NotImplementedException();
    }

    public Task RegistrateAsPsycho()
    {
        throw new NotImplementedException();
    }
}