namespace MentallHealthSupport.Application.Models.Dto;

public record LoginRequest(
    string Email,
    string Password);