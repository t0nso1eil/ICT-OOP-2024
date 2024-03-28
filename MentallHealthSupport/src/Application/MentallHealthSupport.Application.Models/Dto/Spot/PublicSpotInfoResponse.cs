namespace MentallHealthSupport.Application.Models.Dto.Spot;

public record PublicSpotInfoResponse(
    string FirstName,
    string LastName,
    DateOnly Date,
    DateTime StartTime,
    DateTime EndTime,
    string Status)
{
    public static PublicSpotInfoResponse FromSpot(Entities.Spot spot)
    {
        return new PublicSpotInfoResponse(
            spot.Psychologist.User.FirstName,
            spot.Psychologist.User.LastName,
            spot.Date,
            spot.HourStart,
            spot.HourEnd,
            spot.Status);
    }
}