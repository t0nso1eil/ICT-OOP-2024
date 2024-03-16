namespace MentallHealthSupport.Application.Models.Dto;

public record UpdateReviewRequest(
    uint NewRate,
    string NewDescrption);