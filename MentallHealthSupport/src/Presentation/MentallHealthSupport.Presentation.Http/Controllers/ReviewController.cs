using MediatR;
using MentallHealthSupport.Application.Events.Commands.Review;
using MentallHealthSupport.Application.Events.Queries.Review;
using MentallHealthSupport.Application.Exceptions;
using MentallHealthSupport.Application.Models.Dto.Review;
using Microsoft.AspNetCore.Mvc;

namespace MentallHealthSupport.Presentation.Http.Controllers;

[Route("[controller]")]
public class ReviewController : ControllerBase
{
    private readonly IMediator _mediator;

    public ReviewController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> CreateReview([FromBody] CreateReviewRequest request)
    {
        try
        {
            var command = new CreateReviewCommand(request);
            var id = await _mediator.Send(command);
            return Ok(new { ReviewId = id });
        }
        catch (ConflictException ex)
        {
            return Conflict(new { Error = ex.Message });
        }
        catch (IncorrectInputException ex)
        {
            return BadRequest(new { Error = ex.Message });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { Error = ex.Message });
        }
    }

    [HttpPatch("{id}")]
    public async Task<IActionResult> UpdateReview(Guid id, [FromBody] UpdateReviewRequest request)
    {
        try
        {
            var command = new UpdateReviewCommand(id, request);
            var review = await _mediator.Send(command);
            return Ok(review);
        }
        catch (NotFoundException ex)
        {
            return NotFound(new { Error = ex.Message });
        }
        catch (IncorrectInputException ex)
        {
            return BadRequest(new { Error = ex.Message });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { Error = ex.Message });
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteReview(Guid id)
    {
        try
        {
            var command = new DeleteReviewCommand(id);
            await _mediator.Send(command);
            return Ok();
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

    [HttpGet("{psychoId}")]
    public async Task<IActionResult> GetPsychoReviews(Guid psychoId)
    {
        try
        {
            var query = new GetPsychologistReviewsQuery(psychoId);
            var reviews = await _mediator.Send(query);
            return Ok(reviews);
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