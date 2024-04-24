using MediatR;
using MentallHealthSupport.Application.Events.Commands.Spot;
using MentallHealthSupport.Application.Events.Queries.Spot;
using MentallHealthSupport.Application.Exceptions;
using MentallHealthSupport.Application.Models.Dto.Spot;
using Microsoft.AspNetCore.Mvc;

namespace MentallHealthSupport.Presentation.Http.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SpotController : ControllerBase
    {
        private readonly IMediator _mediator;

        public SpotController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateSpot([FromBody] CreateSpotRequest createSpotRequest)
        {
            try
            {
                var command = new CreateSpotCommand(createSpotRequest);
                var spotId = await _mediator.Send(command);
                return Ok(new { SpotId = spotId });
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
        public async Task<IActionResult> UpdateSpotStatus(Guid id, string status)
        {
            try
            {
                var command = new UpdateSpotStatusCommand(id, status);
                var spot = await _mediator.Send(command);
                return Ok(spot);
            }
            catch (NotFoundException ex)
            {
                return NotFound(new { Error = ex.Message });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("/spots/{psychologistId}")]
        public async Task<IActionResult> GetPsychologistFreeSpots(Guid psychologistId)
        {
            try
            {
                var query = new GetPsychologistFreeSpotsQuery(psychologistId);
                var freeSpots = await _mediator.Send(query);
                return Ok(freeSpots);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Error = ex.Message });
            }
        }

        [HttpGet("/schedule/{psychologistId}")]
        public async Task<IActionResult> GetPsychologistSchedule(Guid psychologistId)
        {
            try
            {
                var query = new GetPsychologistScheduleQuery(psychologistId);
                var schedule = await _mediator.Send(query);
                return Ok(schedule);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Error = ex.Message });
            }
        }
    }
}
