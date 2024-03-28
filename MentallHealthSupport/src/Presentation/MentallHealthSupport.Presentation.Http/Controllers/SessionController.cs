#pragma warning disable IDE0161

using MentallHealthSupport.Application.Contracts.Services;
using MentallHealthSupport.Application.Exceptions;
using MentallHealthSupport.Application.Models.Dto.Session;
using Microsoft.AspNetCore.Mvc;

namespace MentallHealthSupport.Presentation.Http.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SessionController : ControllerBase
    {
        private readonly ISessionService _sessionService;

        public SessionController(ISessionService sessionService)
        {
            _sessionService = sessionService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateSession([FromBody] CreateSessionRequest createSessionRequest)
        {
            try
            {
                var sessionId = await _sessionService.CreateNewSession(createSessionRequest);
                return Ok(new { SessionId = sessionId });
            }
            catch (ConflictException ex)
            {
                return StatusCode(409, new { Error = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Error = ex.Message });
            }
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateSessionStatus(Guid id, string status)
        {
            try
            {
                var session = await _sessionService.UpdateSessionStatus(id, status);
                return Ok(session);
            }
            catch (NotFoundException ex)
            {
                return NotFound(new { Error = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Error = ex.Message });
            }
        }

        [HttpGet("{userId}")]
        public async Task<IActionResult> GetUserSessions(Guid userId)
        {
            try
            {
                var sessions = await _sessionService.GetUserSessions(userId);
                return Ok(sessions);
            }
            catch (NotFoundException ex)
            {
                return NotFound(new { Error = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Error = ex.Message });
            }
        }
    }
}
