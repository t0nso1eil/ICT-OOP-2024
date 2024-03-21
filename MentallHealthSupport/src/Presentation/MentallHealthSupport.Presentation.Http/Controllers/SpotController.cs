#pragma warning disable IDE0161

using MentallHealthSupport.Application.Contracts.Services;
using MentallHealthSupport.Application.Exceptions;
using MentallHealthSupport.Application.Models.Dto.Spot;
using Microsoft.AspNetCore.Mvc;

namespace MentallHealthSupport.Presentation.Http.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SpotController : ControllerBase
    {
        private readonly ISpotService _spotService;

        public SpotController(ISpotService spotService)
        {
            _spotService = spotService ?? throw new ArgumentNullException(nameof(spotService));
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateSpot([FromBody] CreateSpotRequest createSpotRequest)
        {
            try
            {
                var spotId = await _spotService.CreateNewSpot(createSpotRequest);
                return Ok(spotId);
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
        public async Task<IActionResult> UpdateSpotStatus(UpdateSpotRequest updateSpotRequest)
        {
            try
            {
                await _spotService.UpdateSpotStatus(updateSpotRequest);
                return NoContent();
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

        [HttpGet("/spots/{id}")]
        public async Task<IActionResult> GetPsychologistFreeSpots(Guid psychologistId)
        {
            try
            {
                var freeSpots = await _spotService.GetPsychologistFreeSpots(psychologistId);
                return Ok(freeSpots);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Error = ex.Message });
            }
        }

        [HttpGet("/schedule/{id}")]
        public async Task<IActionResult> GetPsychologistSchedule(Guid psychologistId)
        {
            try
            {
                var schedule = await _spotService.GetPsychologistSchedule(psychologistId);
                return Ok(schedule);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Error = ex.Message });
            }
        }
    }
}
