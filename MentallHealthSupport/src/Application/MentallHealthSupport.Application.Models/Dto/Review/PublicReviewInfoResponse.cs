namespace MentallHealthSupport.Application.Models.Dto.Review;

public record PublicReviewInfoResponse(
    string PsychologistFirstName,
    string PsychologistLastName,
    string UserFirstName,
    string UserLastName,
    uint Rate, 
    string Description, 
    DateTime PostTime);