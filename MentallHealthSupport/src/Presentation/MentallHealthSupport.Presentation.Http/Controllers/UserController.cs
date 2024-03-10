namespace MentallHealthSupport.Presentation.Http.Controllers;

using MentallHealthSupport.Application.Contracts.Services;
using MentallHealthSupport.Application.Models.Dto;
using Microsoft.AspNetCore.Mvc;

[Route("[controller]/{user_id}")]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet]
    public Task GetUser(Guid id)
    {
        return _userService.GetUser(id, new CancellationToken(false));
    }

    // [HttpPost]
    // public Task CreateUser([FromBody] RegistrateUserDto registrateUserDto)
    // {
    //     return _userService.CreateUser(registrateUserDto, new CancellationToken(false));
    // }
    [HttpPatch]
    public Task UpdateUser(Guid id, [FromBody] UpdateUserDto updateUserDto)
    {
        return _userService.UpdateUser(id, updateUserDto, new CancellationToken(false));
    }
}