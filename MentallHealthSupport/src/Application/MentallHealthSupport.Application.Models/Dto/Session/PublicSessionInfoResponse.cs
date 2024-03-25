namespace MentallHealthSupport.Application.Models.Dto.Session;

public record PublicSessionInfoResponse(
    string PsychologistFirstName,
    string PsychologistLastName,
    string UserFirstName,
    string UserLastName,
    DateOnly Date,
    DateTime StartTime,
    DateTime EndTime,
    string Status,
    decimal Price)
{
    public static PublicSessionInfoResponse FromSession(Entities.Session session)
    {
        return new PublicSessionInfoResponse(
            session.Spot.Psychologist.User.FirstName,
            session.Spot.Psychologist.User.LastName,
            session.User.FirstName,
            session.User.LastName,
            session.Spot.Date,
            session.Spot.HourStart,
            session.Spot.HourEnd,
            session.Status,
            session.Price);
    }
}