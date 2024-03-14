#pragma warning disable CA1721

using MentallHealthSupport.Application.Contracts.Services;
using MentallHealthSupport.Application.Models.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MentallHealthSupport.Presentation.Http.Controllers;
[Authorize("IsAuthenticated")]
[Route("[controller]/users/{user_id}")]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet]
    public Task<PublicUserInfoResponse> GetUser(Guid id)
    {
        return _userService.GetUser(id);
    }

    [HttpPatch]
    public Task UpdateUser(Guid id, [FromBody] UpdateUserRequest updateUserRequest)
    {
        return _userService.UpdateUser(id, updateUserRequest);
    }
}