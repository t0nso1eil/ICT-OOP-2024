using MentallHealthSupport.Application.Models.Entities;

namespace MentallHealthSupport.Application.Models.Dto;

public record CreateSpotRequest(
    Psychologist Psychologist,
    DateOnly Date,
    DateTime StartTime,
    DateTime EndTime,
    string Status);
