namespace MentallHealthSupport.Presentation.Http.Controllers;

using MentallHealthSupport.Application.Models.Dto;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;

[Route("[controller]")]
public class AuthController(IAuthenticationService authenticationService) : ControllerBase
{
    private readonly IAuthenticationService _authenticationService = authenticationService;

    public Task Login([FromBody] LoginDto loginDto)
    {
        throw new NotImplementedException();
    }

    public Task Registrate([FromBody] RegistrateUserDto registrateUserDto)
    {
        throw new NotImplementedException();
    }
}