using Stock.Data.SqlServer.Context;

namespace Stock.Data.SqlServer.Repositories.Base
{
    public class BaseRepository<TEntity> : EfCoreRepository<TEntity, StockContext>
        where TEntity : class
    {
        public BaseRepository(StockContext dbContext)
            : base(dbContext)
        {
        }
    }
}
