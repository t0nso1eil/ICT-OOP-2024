namespace MentallHealthSupport.Application.Models.Dto.Session;

public record CreateSessionRequest(
    string Status,
    decimal Price,
    Guid UserId,
    Guid SpotId)
{
    public Entities.Session ToSession(Entities.User user, Entities.Spot spot)
    {
        return new Entities.Session
        {
            Id = new Guid(),
            Price = Price,
            Spot = spot,
            Status = Status,
            User = user,
        };
    }
}