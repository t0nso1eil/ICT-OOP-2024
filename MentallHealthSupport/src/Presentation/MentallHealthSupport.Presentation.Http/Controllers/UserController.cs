namespace MentallHealthSupport.Presentation.Http.Controllers;

using MentallHealthSupport.Application.Contracts.Services;
using MentallHealthSupport.Application.Models.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[Authorize("IsAuthenticated")]
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
        return _userService.GetUser(id);
    }

    [HttpPatch]
    public Task UpdateUser(Guid id, [FromBody] UpdateUserRequest updateUserRequest)
    {
        return _userService.UpdateUser(id, updateUserRequest);
    }
}