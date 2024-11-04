using Stock.Data.SqlServer.Context;
using Stock.Data.SqlServer.Repositories.Base;
using Stock.Domain.Contracts.Repositories;
using Stock.Domain.Entities;

namespace Stock.Data.SqlServer.Repositories
{
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        public ProductRepository(StockContext context) 
            : base(context) 
        { 
        }
    }
}
