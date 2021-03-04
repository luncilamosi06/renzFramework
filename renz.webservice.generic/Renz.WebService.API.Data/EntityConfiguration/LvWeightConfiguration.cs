using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RivTech.WebService.Generic.Data.Entity;

namespace RivTech.WebService.Generic.Data.EntityConfiguration
{
    public class LvWeightConfiguration : IEntityTypeConfiguration<LvWeight>
    {
        public void Configure(EntityTypeBuilder<LvWeight> builder)
        {
            builder.HasIndex(u => u.Priority).IsUnique();

            builder.Property(e => e.Priority).HasColumnType("varchar(50)").HasMaxLength(50).IsRequired();

            builder.Property(e => e.Type).HasColumnType("varchar(50)").HasMaxLength(50).IsRequired();

            builder.Property(e => e.Rule).IsRequired();

            builder.Property(e => e.Operator).HasColumnType("varchar(50)").HasMaxLength(50).IsRequired();

            builder.Property(e => e.Cost).IsRequired();

            builder.Property(e => e.IsActive).IsRequired();
        }
    }
}
