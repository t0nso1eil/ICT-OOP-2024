using MentallHealthSupport.Application.Models.Entities;

namespace MentallHealthSupport.Application.Models.Dto;

public record CreateSessionRequest(
    string Status,
    decimal Price,
    Guid UserId,
    Guid SpotId
)
{
    public Session ToSession(User user, Spot spot)
    {
        return new Session
        {
            Status = this.Status,
            Price = this.Price,
            User = user,
            Spot = spot
        };
    }
}