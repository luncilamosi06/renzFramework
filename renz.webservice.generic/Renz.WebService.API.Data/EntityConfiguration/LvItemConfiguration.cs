using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RivTech.WebService.Generic.Data.Entity;

namespace RivTech.WebService.Generic.Data.EntityConfiguration
{
    public class LvItemConfiguration : IEntityTypeConfiguration<LvItem>
    {
        public void Configure(EntityTypeBuilder<LvItem> builder)
        {
            builder.HasIndex(u => u.Name).IsUnique();

            builder.Property(e => e.Name).HasColumnType("varchar(50)").HasMaxLength(50).IsRequired();

            builder.Property(e => e.Weight).IsRequired();

            builder.Property(e => e.TotalCost).IsRequired();

            builder.Property(e => e.IsActive).IsRequired();
        }
    }
}
