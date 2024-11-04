using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Stock.Core.Storage.Paginated;
using Stock.Data.SqlServer.Storage.Paginated;
using Stock.Domain.Contracts.Repositories;
using Stock.Domain.Contracts.Storage;
using System.Linq.Expressions;

namespace Stock.Data.SqlServer.Repositories.Base
{
    public class EfCoreRepository<TEntity, TContext> : IBaseRepository<TEntity>
        where TEntity : class
        where TContext: DbContext
    {
        private readonly TContext _context;

        private readonly DbSet<TEntity> _dbSet;

        public EfCoreRepository(TContext dbContext)
        {
            if (dbContext == null)
            {
                throw new ArgumentNullException(nameof(dbContext));
            }

            _dbSet = dbContext.Set<TEntity>();
            _context = dbContext;
        }

        protected TContext Context => _context;

        public async Task<TEntity> AddAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            var added = await _dbSet.AddAsync(entity, cancellationToken);
            return added.Entity;
        }

        public async Task AddRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default)
        {
            await _dbSet.AddRangeAsync(entities,cancellationToken);
        }

        public void Remove(TEntity entity)
        {
            _dbSet.Remove(entity);
        }

        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            _dbSet.RemoveRange(entities);
        }

        public TEntity Update(TEntity entity)
        {
            if (Context.Entry(entity).State != EntityState.Detached)
            {
                return entity;
            }

            var added = _dbSet.Update(entity);

            return added.Entity;
        }

        public async Task<bool> AnyAsync(Expression<Func<TEntity, bool>> predicate = null, QueryTrackingBehavior queryTracking = QueryTrackingBehavior.NoTracking)
        {
            return await _dbSet.AsQueryable().Where(predicate).AsTracking(queryTracking).AnyAsync(cancellationToken: default);
        }

        public async Task<int> CountAsync(Expression<Func<TEntity, bool>> predicate = null, QueryTrackingBehavior queryTracking = QueryTrackingBehavior.NoTracking)
        {
            var query = FilterAndOrder<object>(predicate, null, true, null);
            return await query.AsTracking(queryTracking).CountAsync(cancellationToken: default);
        }

        #region FirstOrDefaultAsync
        public async Task<TEntity> FirstOrDefaultAsync(QueryTrackingBehavior queryTracking = QueryTrackingBehavior.NoTracking)
        {
            var query = FilterAndOrder<object>(null, null, true, null);
            return await query.AsTracking(queryTracking).FirstOrDefaultAsync(cancellationToken: default);
        }

        public async Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate, QueryTrackingBehavior queryTracking = QueryTrackingBehavior.NoTracking)
        {
            var query = FilterAndOrder<object>(predicate, null, true, null);
            return await query.AsTracking(queryTracking).FirstOrDefaultAsync(cancellationToken: default);
        }

        public async Task<TEntity> FirstOrDefaultAsync(
            Expression<Func<TEntity, bool>> predicate,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> includes,
            QueryTrackingBehavior queryTracking = QueryTrackingBehavior.NoTracking)
        {
            var query = FilterAndOrder<object>(predicate, null, true, includes);
            return await query.AsTracking(queryTracking).FirstOrDefaultAsync(cancellationToken: default);
        }

        public async Task<TResponse> FirstOrDefaultAsync<TResponse>(
            Expression<Func<TEntity, bool>> predicate = null,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> includes = null,
            Expression<Func<TEntity, TResponse>> fieldsSelect = null,
            QueryTrackingBehavior queryTracking = QueryTrackingBehavior.NoTracking)
        {
            var query = FilterAndOrder<object>(predicate, null, true, includes);
            return await query.AsTracking(queryTracking).Select(fieldsSelect).FirstOrDefaultAsync(cancellationToken: default);
        }
        #endregion FirstOrDefaultAsync

        #region FirstOrDefaultOrdered
        public async Task<TEntity> FirstOrDefaultOrdered<TField>(Expression<Func<TEntity, TField>> orderByKeySelector, bool orderAscending)
        {
            var query = FilterAndOrder(null, orderByKeySelector, orderAscending, null);

            return await query.FirstOrDefaultAsync(cancellationToken: default);
        }

        public async Task<TEntity> FirstOrDefaultOrdered<TField>(
            Expression<Func<TEntity, bool>> predicate,
            Expression<Func<TEntity, TField>> orderByKeySelector,
            bool orderAscending)
        {
            var query = FilterAndOrder(predicate, orderByKeySelector, orderAscending, null);
            return await query.FirstOrDefaultAsync(cancellationToken: default);
        }

        public async Task<TEntity> FirstOrDefaultOrdered<TField>(
            Expression<Func<TEntity, bool>> predicate,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> includes,
            Expression<Func<TEntity, TField>> orderByKeySelector,
            bool orderAscending)
        {
            var query = FilterAndOrder(predicate, orderByKeySelector, orderAscending, includes);
            return await query.FirstOrDefaultAsync(cancellationToken: default);
        }

        public async Task<TResponse> FirstOrDefaultOrdered<TField, TResponse>(
            Expression<Func<TEntity, bool>> predicate = null,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> includes = null,
            Expression<Func<TEntity, TResponse>> fieldsSelect = null,
            Expression<Func<TEntity, TField>> orderByKeySelector = null,
            bool orderAscending = true)
        {
            var query = FilterAndOrder(predicate, orderByKeySelector, orderAscending, includes);
            return await query.Select(fieldsSelect).FirstOrDefaultAsync(cancellationToken: default);
        }
        #endregion FirstOrDefaultOrdered

        #region GetAsync

        public async Task<IEnumerable<TEntity>> GetAsync(QueryTrackingBehavior queryTracking = QueryTrackingBehavior.NoTracking)
        {
            var query = FilterAndOrder<object>(null, null, true, null);
            return await query.AsTracking(queryTracking).ToListAsync(cancellationToken: default);
        }

        public async Task<IEnumerable<TEntity>> GetAsync(Expression<Func<TEntity, bool>> predicate, QueryTrackingBehavior queryTracking = QueryTrackingBehavior.NoTracking)
        {
            var query = FilterAndOrder<object>(predicate, null, true, null);
            return await query.AsTracking(queryTracking).ToListAsync(cancellationToken: default);
        }

        public async Task<IEnumerable<TEntity>> GetAsync(Expression<Func<TEntity, bool>> predicate, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> includes, QueryTrackingBehavior queryTracking = QueryTrackingBehavior.NoTracking)
        {
            var query = FilterAndOrder<object>(predicate, null, true, includes);
            return await query.AsTracking(queryTracking).ToListAsync(cancellationToken: default);
        }

        public async Task<IEnumerable<TResponse>> GetAsync<TResponse>(
            Expression<Func<TEntity, bool>> predicate = null,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> includes = null,
            Expression<Func<TEntity, TResponse>> fieldsSelect = null,
            QueryTrackingBehavior queryTracking = QueryTrackingBehavior.NoTracking)
        {
            var query = FilterAndOrder<object>(predicate, null, true, includes);
            return await query.AsTracking(queryTracking).Select(fieldsSelect).ToListAsync(cancellationToken: default);
        }

        #endregion GetAsync

        #region GetOrdered

        public async Task<IEnumerable<TEntity>> GetOrdered<TField>(Expression<Func<TEntity, TField>> orderByKeySelector, bool orderAscending, QueryTrackingBehavior queryTracking = QueryTrackingBehavior.NoTracking)
        {
            var query = FilterAndOrder(null, orderByKeySelector, orderAscending, null);
            return await query.AsTracking(queryTracking).ToListAsync(cancellationToken: default);
        }

        public async Task<IEnumerable<TEntity>> GetOrdered<TField>(Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, TField>> orderByKeySelector, bool orderAscending, QueryTrackingBehavior queryTracking = QueryTrackingBehavior.NoTracking)
        {
            var query = FilterAndOrder(predicate, orderByKeySelector, orderAscending, null);
            return await query.AsTracking(queryTracking).ToListAsync(cancellationToken: default);
        }

        public async Task<IEnumerable<TEntity>> GetOrdered<TField>(
            Expression<Func<TEntity, bool>> predicate,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> includes,
            Expression<Func<TEntity, TField>> orderByKeySelector,
            bool orderAscending,
            QueryTrackingBehavior queryTracking = QueryTrackingBehavior.NoTracking)
        {
            var query = FilterAndOrder(null, orderByKeySelector, orderAscending, includes);

            return await query.AsTracking(queryTracking).ToListAsync(cancellationToken: default);
        }

        public async Task<IEnumerable<TEntity>> GetOrdered<TField>(
            Expression<Func<TEntity, bool>> predicate = null,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> includes = null,
            Expression<Func<TEntity, TField>> orderByKeySelector = null,
            bool orderAscending = true,
            int? take = null,
            QueryTrackingBehavior queryTracking = QueryTrackingBehavior.NoTracking)
        {
            var query = FilterAndOrder(predicate, orderByKeySelector, orderAscending, includes);
            if (take > 0)
            {
                query = query.Take(take.Value);
            }

            return await query.AsTracking(queryTracking).ToListAsync(cancellationToken: default);
        }

        public async Task<IEnumerable<TResponse>> GetOrdered<TField, TResponse>(
            Expression<Func<TEntity, bool>> predicate = null,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> includes = null,
            Expression<Func<TEntity, TResponse>> fieldsSelect = null,
            Expression<Func<TEntity, TField>> orderByKeySelector = null,
            bool orderAscending = true,
            int? take = null,
            QueryTrackingBehavior queryTracking = QueryTrackingBehavior.NoTracking)
        {
            var query = FilterAndOrder(predicate, orderByKeySelector, orderAscending, includes);
            if (take > 0)
            {
                query = query.Take(take.Value);
            }

            return await query.AsTracking(queryTracking).Select(fieldsSelect).ToListAsync(cancellationToken: default);
        }

        #endregion GetOrdered

        #region GetPaginatedAsync

        public async Task<PaginatedList<TEntity>> GetPaginatedAsync<TField>(
            Expression<Func<TEntity, bool>> predicate,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> includes,
            int page,
            int pageSize,
            Expression<Func<TEntity, TField>> orderByKeySelector,
            bool orderAscending,
            QueryTrackingBehavior queryTracking = QueryTrackingBehavior.NoTracking)
        {
            var query = FilterAndOrder(predicate, orderByKeySelector, orderAscending, includes);
            return await OffsetPagination(query, page, pageSize, queryTracking);
        }

        public async Task<PaginatedList<TResponse>> GetPaginatedAsync<TField, TResponse>(
            Expression<Func<TEntity, bool>> predicate = null,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> includes = null,
            Expression<Func<TEntity, TResponse>> fieldsSelect = null,
            int page = 0,
            int pageSize = 0,
            Expression<Func<TEntity, TField>> orderByKeySelector = null,
            bool orderAscending = true,
            QueryTrackingBehavior queryTracking = QueryTrackingBehavior.NoTracking)
        {
            var query = FilterAndOrder(predicate, orderByKeySelector, orderAscending, includes);
            return await OffsetPagination(query, fieldsSelect, page, pageSize, queryTracking);
        }

        public async Task<PaginatedList<TEntity>> GetPaginatedAsync<TField, TTargetEntity>(
            Expression<Func<TEntity, bool>> predicate,
            Expression<Func<TEntity, TField>> orderByKeySelector,
            int lastId,
            OperatorsSupportedPaging lastIdOperator,
            int pageSize,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> includes = null,
            bool orderAscending = true,
            QueryTrackingBehavior queryTracking = QueryTrackingBehavior.NoTracking)
            where TTargetEntity : class, IEntity
        {
            var query = FilterAndOrder<TField, TTargetEntity>(predicate, orderByKeySelector, orderAscending, includes);
            return await KeysetPagination(query, lastId, pageSize, lastIdOperator, queryTracking);
        }

        public async Task<PaginatedList<TResponse>> GetPaginatedAsync<TField, TResponse, TTargetEntity>(
            Expression<Func<TEntity, bool>> predicate,
            Expression<Func<TEntity, TResponse>> fieldsSelect,
            Expression<Func<TEntity, TField>> orderByKeySelector,
            int lastId,
            OperatorsSupportedPaging lastIdOperator,
            int pageSize,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> includes = null,
            bool orderAscending = true,
            QueryTrackingBehavior queryTracking = QueryTrackingBehavior.NoTracking)
            where TTargetEntity : class, IEntity
        {
            var query = FilterAndOrder<TField, TTargetEntity>(predicate, orderByKeySelector, orderAscending, includes);
            return await KeysetPagination(query, lastId, pageSize, fieldsSelect, lastIdOperator, queryTracking);
        }
        #endregion GetPaginatedAsync

        #region Paginate

        private async Task<PaginatedList<TEntity>> OffsetPagination(
            IQueryable<TEntity> query,
            int page,
            int pageSize,
            QueryTrackingBehavior queryTracking = QueryTrackingBehavior.NoTracking)
        {
            var totalItems = await query.CountAsync(cancellationToken: default);

            var items = await query
                .Skip(pageSize * (page - 1))
                .Take(pageSize)
                .AsTracking(queryTracking)
                .ToListAsync(cancellationToken: default);

            return new PaginatedList<TEntity>(items, totalItems, page, pageSize);
        }

        private async Task<PaginatedList<TResponse>> OffsetPagination<TResponse>(
            IQueryable<TEntity> query,
            Expression<Func<TEntity, TResponse>> fieldsSelect,
            int page,
            int pageSize,
            QueryTrackingBehavior queryTracking = QueryTrackingBehavior.NoTracking)
        {
            var totalItems = await query.CountAsync(cancellationToken: default);

            var items = await query
                .Skip(pageSize * (page - 1))
                .Take(pageSize)
                .AsTracking(queryTracking)
                .Select(fieldsSelect)
                .ToListAsync(cancellationToken: default);

            return new PaginatedList<TResponse>(items, totalItems, page, pageSize);
        }

        private async Task<PaginatedList<TEntity>> KeysetPagination<TTargetEntity>(
            IQueryable<TTargetEntity> query,
            int lastId,
            int pageSize,
            OperatorsSupportedPaging lastIdOperator,
            QueryTrackingBehavior queryTracking = QueryTrackingBehavior.NoTracking)
            where TTargetEntity : class, IEntity
        {
            var totalItems = await query.CountAsync(cancellationToken: default);
            var queryWithFilter = (IQueryable<TEntity>)query.Where(x => (x.Id > lastId && lastIdOperator == OperatorsSupportedPaging.GreaterThan) || (x.Id < lastId && lastIdOperator == OperatorsSupportedPaging.LessThan));

            var remainingItems = await queryWithFilter.CountAsync(cancellationToken: default);

            var items = await queryWithFilter
                .Take(pageSize)
                .AsTracking(queryTracking)
                .ToListAsync(cancellationToken: default);

            var paginatedList = new PaginatedList<TEntity>(items, totalItems, 0, pageSize);
            paginatedList.SetCurrentPage(remainingItems);
            return paginatedList;
        }

        private async Task<PaginatedList<TResponse>> KeysetPagination<TResponse, TTargetEntity>(
            IQueryable<TTargetEntity> query,
            int lastId,
            int pageSize,
            Expression<Func<TEntity, TResponse>> fieldsSelect,
            OperatorsSupportedPaging lastIdOperator,
            QueryTrackingBehavior queryTracking = QueryTrackingBehavior.NoTracking)
            where TTargetEntity : class, IEntity
        {
            var totalItems = await query.CountAsync(cancellationToken: default);

            if (lastIdOperator == OperatorsSupportedPaging.LessThan && lastId <= 0)
            {
                lastId = int.MaxValue;
            }

            var queryWithFilter = (IQueryable<TEntity>)query.Where(x => (x.Id > lastId && lastIdOperator == OperatorsSupportedPaging.GreaterThan) || (x.Id < lastId && lastIdOperator == OperatorsSupportedPaging.LessThan));

            var remainingItems = await queryWithFilter.CountAsync(cancellationToken: default);

            var items = await queryWithFilter
                .Take(pageSize)
                .AsTracking(queryTracking)
                .Select(fieldsSelect)
                .ToListAsync(cancellationToken: default);

            var paginatedList = new PaginatedList<TResponse>(items, totalItems, 0, pageSize);
            paginatedList.SetCurrentPage(remainingItems);
            return paginatedList;
        }

        #endregion Paginate

        #region FilterAndOrder
        private IQueryable<TEntity> FilterAndOrder<TField>(
            Expression<Func<TEntity, bool>> predicate,
            Expression<Func<TEntity, TField>> orderByKeySelector,
            bool orderAscending,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> includes = null)
        {
            var query = (IQueryable<TEntity>)FilterAndOrder(predicate, orderByKeySelector, includes, orderAscending);
            return query;
        }

        private IQueryable<TTargetEntity> FilterAndOrder<TField, TTargetEntity>(
            Expression<Func<TEntity, bool>> predicate,
            Expression<Func<TEntity, TField>> orderByKeySelector,
            bool orderAscending,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> includes = null)
        {
            var query = (IQueryable<TTargetEntity>)FilterAndOrder(predicate, orderByKeySelector, includes, orderAscending);
            return query;
        }

        private IQueryable FilterAndOrder<TField>(
            Expression<Func<TEntity, bool>> predicate,
            Expression<Func<TEntity, TField>> orderByKeySelector = null,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> includes = null,
            bool orderAscending = true)
        {
            var query = _dbSet.AsQueryable();

            if (predicate != null)
            {
                query = query.Where(predicate);
            }

            if (orderByKeySelector != null)
            {
                query = orderAscending ? query.OrderBy(orderByKeySelector) : query.OrderByDescending(orderByKeySelector);
            }

            if (includes != null)
            {
                query = includes(query);
            }

            return query;
        }

        #endregion FilterAndOrder
    }
}
