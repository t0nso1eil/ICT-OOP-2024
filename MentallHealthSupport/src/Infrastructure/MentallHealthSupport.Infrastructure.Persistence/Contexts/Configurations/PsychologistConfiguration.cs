using MentallHealthSupport.Infrastructure.Persistence.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MentallHealthSupport.Infrastructure.Persistence.Contexts.Configurations;
public class PsychologistConfiguration : IEntityTypeConfiguration<PsychologistModel>
{
    public void Configure(EntityTypeBuilder<PsychologistModel> builder)
    {
        // прописать то, как все поля и constrains должны выглядеть в бд
        builder.HasKey(psychologist => psychologist.Id);
        builder.HasOne(psychologist => psychologist.User).WithOne(user => user.Psychologist);
        builder.HasMany(psychologist => psychologist.Reviews).WithOne(review => review.Psychologist);
        builder.HasMany(psychologist => psychologist.Spots).WithOne(spot => spot.Psychologist);
    }
}