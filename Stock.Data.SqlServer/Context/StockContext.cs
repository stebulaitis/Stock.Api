using Microsoft.EntityFrameworkCore;
using Stock.Data.SqlServer.Configuration;
using Stock.Domain.Entities;

namespace Stock.Data.SqlServer.Context
{
    public class StockContext : DbContext
    {
        public StockContext(DbContextOptions<StockContext> options) : base(options) { }

        public DbSet<Product> Product { get; set; }

        public DbSet<Brand> Brand { get; set; }

        public DbSet<Size> Size { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new SizeConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
