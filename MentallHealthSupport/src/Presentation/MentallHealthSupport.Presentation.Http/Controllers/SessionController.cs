using MentallHealthSupport.Application.Contracts;
using MentallHealthSupport.Application.Models.Dto;
using Microsoft.AspNetCore.Mvc;

namespace MentallHealthSupport.Presentation.Http.Controllers;

public class SessionController : ControllerBase
{
    private readonly ISessionService _sessionService;

    public SessionController(ISessionService sessionService)
    {
        _sessionService = sessionService;
    }

    [HttpGet]
    public Task<PublicSession>;

    [HttpPatch]
    public Task UpdateSession(Guid id, [FromBody] UpdateSessionRequest updateSessionRequest)
    {
        return _sessionService.UpdateSession(id, updateSessionRequest);
    }
}