namespace MentallHealthSupport.Infrastructure.Persistence.Models;

public class PsychologistModel
{
    public Guid Id; 
    public ICollection<SpotModel> Spots { get; set; } = new List<SpotModel>();
}