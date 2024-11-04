using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.ValueGeneration;
using Stock.Domain.Entities;

namespace Stock.Data.SqlServer.Configuration
{
    public class ProductConfiguration : EntityBaseConfiguration<Product>
    {
        public override void Configure(EntityTypeBuilder<Product> builder)
        {
            base.Configure(builder);

            builder
                .Property(p => p.Key)
                .HasValueGenerator<SequentialGuidValueGenerator>()
                .IsRequired();

            builder
                .Property(p => p.Name)
                .HasMaxLength(500)
                .IsRequired();

            builder
                .Property(p => p.Active)
                .IsRequired();

            builder
                .HasIndex(p => p.Key);

            builder
                .HasIndex(p => p.Name);

            builder
                .HasIndex(p => new { p.Key, p.Active });
        }
    }
}
