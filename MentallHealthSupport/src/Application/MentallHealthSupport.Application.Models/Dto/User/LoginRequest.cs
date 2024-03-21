namespace MentallHealthSupport.Application.Models.Dto.User;

public record LoginRequest(
    string Email,
    string Password);