#pragma warning disable CA1721
#pragma warning disable IDE0005
#pragma warning disable SA1507


using MediatR;
using MentallHealthSupport.Application.Events.Commands.User;
using MentallHealthSupport.Application.Events.Queries.User;
using MentallHealthSupport.Application.Exceptions;
using MentallHealthSupport.Application.Models.Dto.User;
using Microsoft.AspNetCore.Mvc;

namespace MentallHealthSupport.Presentation.Http.Controllers;

    [ApiController]
    [Route("[controller]")]
    public class UserController(IMediator mediator) : ControllerBase
    {
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser(Guid id)
        {
            try
            {
                var query = new GetUserQuery(id);
                var userInfo = await mediator.Send(query);
                return Ok(userInfo);
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

        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateUser(Guid id, [FromBody] UpdateUserRequest updateUserRequest)
        {
            try
            {
                var command = new UpdateUserCommand(id, updateUserRequest);
                var updatedUserInfo = await mediator.Send(command);
                return Ok(updatedUserInfo);
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
    }