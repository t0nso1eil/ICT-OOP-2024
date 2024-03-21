#pragma warning disable CA2227
#pragma warning disable CA1724

namespace MentallHealthSupport.Application.Models.Entities;

public class Psychologist
{
    public Guid Id { get; set; }

    public User User { get; set; } = null!;

    public string Specialization { get; set; } = null!;

    public DateOnly ExperienceStartDate { get; set; }

    public uint ExperienceYears { get; set; }

    public decimal PricePerHour { get; set; }

    public float? Rate { get; set; }

    public ICollection<Review> Reviews { get; set; } = new List<Review>();

    public ICollection<Spot> Spots { get; set; } = new List<Spot>();
}