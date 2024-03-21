using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MentallHealthSupport.Application.Contracts;
using MentallHealthSupport.Application.Exceptions;
using MentallHealthSupport.Application.Models.Dto;

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

        [HttpPost("create")]
        public async Task<IActionResult> CreateSession([FromBody] CreateSessionRequest createSessionRequest)
        {
            try
            {
                var sessionId = await _sessionService.CreateNewSession(createSessionRequest);
                return Ok(sessionId);
            }
            catch (ConflictException ex)
            {
                return StatusCode(409, new { Error = ex.Message });
            }
            
            catch (Exception ex)
            {
                return StatusCode(500, new { Error = ex.Message});
            }
        }

        [HttpPost]
        [Route("update-status")]
        public async Task<IActionResult> UpdateSessionStatus([FromBody] UpdateSessionRequest updateSessionRequest)
        {
            try
            {
                await _sessionService.UpdateSessionStatus(updateSessionRequest);
                return Ok(updateSessionRequest);
            }
            catch (NotFoundException ex)
            {
                return NotFound(new { Error = ex.Message});
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Error = ex.Message});
            }
        }

        [HttpGet]
        [Route("user-sessions/{userId}")]
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
