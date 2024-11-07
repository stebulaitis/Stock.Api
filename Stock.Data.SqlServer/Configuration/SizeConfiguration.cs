using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Stock.Domain.Entities;
using Stock.Domain.Enumerators;

namespace Stock.Data.SqlServer.Configuration
{
    public class SizeConfiguration : IEntityTypeConfiguration<Size>
    {
        public void Configure(EntityTypeBuilder<Size> builder)
        {
            builder
                .Property(d => d.Id)
                .IsRequired()
                .ValueGeneratedNever();

            builder
                .Property(d => d.Description)
                .HasConversion<string>()
                .IsRequired();

            builder
                .HasData(
                Enum.GetValues(typeof(SizeEnum))
                .Cast<SizeEnum>()
                .Select(e => new Size()
                {
                    Id = (int)e,
                    Description = e.ToString()
                }));
        }
    }
}
