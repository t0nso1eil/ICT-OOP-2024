#pragma warning disable CA2227

namespace MentallHealthSupport.Infrastructure.Persistence.Models;

public class PsychologistModel
{
    public Guid Id { get; set; }

    public Guid UserId { get; set; }

    public UserModel User { get; set; } = null!;

    public string Specialization { get; set; } = null!;

    public DateOnly ExperienceStartDate { get; set; }

    public uint ExperienceYears { get; set; }

    public decimal PricePerHour { get; set; }

    public float Rate { get; set; }

    public ICollection<ReviewModel> Reviews { get; set; } = new List<ReviewModel>();

    public ICollection<SpotModel> Spots { get; set; } = new List<SpotModel>();
}