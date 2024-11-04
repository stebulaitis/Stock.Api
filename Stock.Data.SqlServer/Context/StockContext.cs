using Microsoft.EntityFrameworkCore;
using Stock.Domain.Entities;

namespace Stock.Data.SqlServer.Context
{
    public class StockContext : DbContext
    {
        public StockContext(DbContextOptions<StockContext> options) : base(options) { }

        public DbSet<Product> Products { get; set; }
    }
}
