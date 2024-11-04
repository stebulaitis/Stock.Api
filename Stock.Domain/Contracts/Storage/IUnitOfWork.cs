using System.Threading.Tasks;

namespace Stock.Domain.Contracts.Storage
{
    public interface IUnitOfWork
    {
        void Rollback();

        Task<int> CommitAsync();

        void BeginTransaction();

        void CommitTransaction();

        void RollBackTransaction();
    }
}
