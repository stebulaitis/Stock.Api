using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Stock.Domain.Contracts.Storage;

namespace Stock.Data.SqlServer.UnitOfWork
{
    public class UnitOfWork<TContext> : IUnitOfWork
        where TContext : DbContext
    {
        private readonly TContext _context;

        public UnitOfWork(TContext context)
        {
            _context = context;
        }

        public Task<int> CommitAsync()
        {
            return _context?.SaveChangesAsync();
        }

        public void Rollback()
        {
            _context?.ChangeTracker.Entries().ToList().ForEach(delegate (EntityEntry x)
            {
                x.Reload();
            });
        }

        public void BeginTransaction()
        {
            _context?.Database.BeginTransaction();
        }

        public void CommitTransaction()
        {
            if (_context?.Database?.CurrentTransaction != null)
            {
                _context?.Database.CommitTransaction();
            }
        }

        public void RollBackTransaction()
        {
            if (_context?.Database?.CurrentTransaction != null)
            {
                _context?.Database.RollbackTransaction();
            }
        }
    }
}
