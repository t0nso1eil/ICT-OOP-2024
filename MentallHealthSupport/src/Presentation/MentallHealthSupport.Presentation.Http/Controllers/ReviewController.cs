using MentallHealthSupport.Application.Contracts.Services;
using MentallHealthSupport.Application.Models.Dto.Review;
using Microsoft.AspNetCore.Mvc;

namespace MentallHealthSupport.Presentation.Http.Controllers;

[Route("[controller]")]
public class ReviewController : ControllerBase
{
    private readonly IReviewService _service;

    public ReviewController(IReviewService service)
    {
        _service = service;
    }

    [HttpPost]
    public Task CreateReview([FromBody] CreateReviewRequest request)
    {
        return _service.CreateReview(request);
    }

    [HttpPatch("{id}")]
    public Task UpdateReview(Guid id, [FromBody] UpdateReviewRequest request)
    {
        return _service.UpdateReview(id, request);
    }

    [HttpDelete("{id}")]
    public Task DeleteReview(Guid id)
    {
        return _service.DeleteReview(id);
    }

    [HttpGet("{psychoId}")]
    public ICollection<PublicReviewInfoResponse> GetPsychoReviews(Guid psychoId)
    {
        return _service.GetPsychologistReviews(psychoId);
    }
}