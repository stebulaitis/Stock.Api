using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Stock.Domain.Entities;

namespace Stock.Data.SqlServer.Configuration
{
    public abstract class EntityBaseConfiguration<TModel> : IEntityTypeConfiguration<TModel>
        where TModel : EntityBase
    {
        public virtual void Configure(EntityTypeBuilder<TModel> builder)
        {
            builder.HasKey(p => p.Id);

            builder
                .Property(p => p.CreatedDate)
                .IsRequired();
        }
    }
}
