#pragma warning disable IDE0161

using MediatR;
using MentallHealthSupport.Application.Events.Commands.Session;
using MentallHealthSupport.Application.Events.Queries.Session;
using MentallHealthSupport.Application.Exceptions;
using MentallHealthSupport.Application.Models.Dto.Session;
using Microsoft.AspNetCore.Mvc;

namespace MentallHealthSupport.Presentation.Http.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SessionController : ControllerBase
    {
        private readonly IMediator _mediator;

        public SessionController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateSession([FromBody] CreateSessionRequest createSessionRequest)
        {
            try
            {
                var command = new CreateSessionCommand(createSessionRequest);
                var sessionId = await _mediator.Send(command);
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
                var command = new UpdateSessionCommand(id, status);
                var session = await _mediator.Send(command);
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
                var query = new GetUserSessionsQuery(userId);
                var sessions = await _mediator.Send(query);
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
