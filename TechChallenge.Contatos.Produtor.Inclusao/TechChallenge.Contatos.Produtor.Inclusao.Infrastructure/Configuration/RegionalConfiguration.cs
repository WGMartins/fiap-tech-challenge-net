using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TechChallenge.Domain.RegionalAggregate;

namespace TechChallenge.Infrastructure.Configuration
{
    public class RegionalConfiguration : IEntityTypeConfiguration<Regional>
    {
        public void Configure(EntityTypeBuilder<Regional> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(e => e.Id);
            builder.Property(e => e.CriadoEm).HasColumnType("timestamp without time zone").IsRequired();
            builder.Property(e => e.AlteradoEm).HasColumnType("timestamp without time zone");
            builder.Property(e => e.Ddd).IsRequired();
            builder.Property(e => e.Estado).HasMaxLength(2).IsRequired();
            builder.Property(e => e.Nome).HasMaxLength(100).IsRequired();
        }
    }
}
