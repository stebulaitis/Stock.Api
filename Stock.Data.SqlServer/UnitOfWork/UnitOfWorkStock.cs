using Stock.Data.SqlServer.Context;

namespace Stock.Data.SqlServer.UnitOfWork
{
    public class UnitOfWorkStock : UnitOfWork<StockContext>
    {
        public UnitOfWorkStock(StockContext dbContext)
            :base(dbContext)
        {            
        }
    }
}
