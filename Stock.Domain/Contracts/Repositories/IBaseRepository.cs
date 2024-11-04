using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Stock.Core.Storage.Paginated;
using Stock.Data.SqlServer.Storage.Paginated;
using Stock.Domain.Contracts.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace Stock.Domain.Contracts.Repositories
{
    public interface IBaseRepository<TEntity>
    where TEntity : class
    {
        #region FirstOrDefaultAsync

        /// <summary>
        /// Returns the first element of a sequence, or a default value if the sequence contains no elements.
        /// </summary>
        /// <param name="queryTracking">query tracking.</param>
        /// <returns>entity record if any.</returns>
        Task<TEntity> FirstOrDefaultAsync(QueryTrackingBehavior queryTracking = QueryTrackingBehavior.NoTracking);

        /// <summary>
        /// Returns the first element of a sequence, or a default value if the sequence contains no elements.
        /// </summary>
        /// <param name="predicate">query predicate.</param>
        /// <param name="queryTracking">query tracking.</param>
        /// <returns>The task result contains default (TEntity) if source is empty; otherwise, the first element in source.</returns>
        Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate, QueryTrackingBehavior queryTracking = QueryTrackingBehavior.NoTracking);

        /// <summary>
        /// Returns the first element of a sequence, or a default value if the sequence contains no elements.
        /// </summary>
        /// <param name="predicate">query predicate.</param>
        /// <param name="includes">includes.</param>
        /// <param name="queryTracking">query tracking.</param>
        /// <returns>The task result contains default (TEntity) if source is empty; otherwise, the first element in source.</returns>
        Task<TEntity> FirstOrDefaultAsync(
            Expression<Func<TEntity, bool>> predicate,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> includes,
            QueryTrackingBehavior queryTracking = QueryTrackingBehavior.NoTracking);

        /// <summary>
        /// Returns the first element of a sequence, or a default value if the sequence contains no elements.
        /// </summary>
        /// <typeparam name="TResponse">response object type.</typeparam>
        /// <param name="predicate">query predicate.</param>
        /// <param name="includes">includes.</param>
        /// <param name="fieldsSelect">fields select.</param>
        /// <param name="queryTracking">query tracking.</param>
        /// <returns>The task result contains default (TEntity) if source is empty; otherwise, the first element in source.</returns>
        Task<TResponse> FirstOrDefaultAsync<TResponse>(
            Expression<Func<TEntity, bool>> predicate = null,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> includes = null,
            Expression<Func<TEntity, TResponse>> fieldsSelect = null,
            QueryTrackingBehavior queryTracking = QueryTrackingBehavior.NoTracking);

        #endregion FirstOrDefaultAsync

        #region FirstOrDefaultOrdered

        /// <summary>
        /// Returns the first element of a sequence, or a default value if the sequence contains no elements.
        /// </summary>
        /// <typeparam name="TField">field to orderby.</typeparam>
        /// <param name="orderByKeySelector">orderby clause.</param>
        /// <param name="orderAscending">type ordenation (asc, desc).</param>
        /// <returns>The task result contains default (TEntity) if source is empty; otherwise, the first element in source.</returns>
        Task<TEntity> FirstOrDefaultOrdered<TField>(Expression<Func<TEntity, TField>> orderByKeySelector, bool orderAscending);

        /// <summary>
        /// Returns the first element of a sequence, or a default value if the sequence contains no elements.
        /// </summary>
        /// <typeparam name="TField">field to orderby.</typeparam>
        /// <param name="predicate">query predicate.</param>
        /// <param name="orderByKeySelector">orderby clause.</param>
        /// <param name="orderAscending">type ordenation (asc, desc).</param>
        /// <returns>The task result contains default (TEntity) if source is empty; otherwise, the first element in source.</returns>
        Task<TEntity> FirstOrDefaultOrdered<TField>(
            Expression<Func<TEntity, bool>> predicate,
            Expression<Func<TEntity, TField>> orderByKeySelector,
            bool orderAscending);

        /// <summary>
        /// Returns the first element of a sequence, or a default value if the sequence contains no elements.
        /// </summary>
        /// <typeparam name="TField">field to orderby.</typeparam>
        /// <param name="predicate">query predicate.</param>
        /// <param name="includes">query includes.</param>
        /// <param name="orderByKeySelector">orderby clause.</param>
        /// <param name="orderAscending">type ordenation (asc, desc).</param>
        /// <returns>The task result contains default (TEntity) if source is empty; otherwise, the first element in source.</returns>
        Task<TEntity> FirstOrDefaultOrdered<TField>(
            Expression<Func<TEntity, bool>> predicate,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> includes,
            Expression<Func<TEntity, TField>> orderByKeySelector,
            bool orderAscending);

        /// <summary>
        /// Returns the first element of a sequence, or a default value if the sequence contains no elements.
        /// </summary>
        /// <typeparam name="TField">field to orderby.</typeparam>
        /// <typeparam name="TResponse">response object type.</typeparam>
        /// <param name="predicate">query predicate.</param>
        /// <param name="includes">query includes.</param>
        /// <param name="fieldsSelect">fields select.</param>
        /// <param name="orderByKeySelector">orderby clause.</param>
        /// <param name="orderAscending">type ordenation (asc, desc).</param>
        /// <returns>The task result contains default (TEntity) if source is empty; otherwise, the first element in source.</returns>
        Task<TResponse> FirstOrDefaultOrdered<TField, TResponse>(
            Expression<Func<TEntity, bool>> predicate = null,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> includes = null,
            Expression<Func<TEntity, TResponse>> fieldsSelect = null,
            Expression<Func<TEntity, TField>> orderByKeySelector = null,
            bool orderAscending = true);

        #endregion FirstOrDefaultOrdered

        #region GetAsync

        /// <summary>
        /// Get all elements.
        /// </summary>
        /// <param name="queryTracking">query tracking.</param>
        /// <returns>All elements in source.</returns>
        Task<IEnumerable<TEntity>> GetAsync(QueryTrackingBehavior queryTracking = QueryTrackingBehavior.NoTracking);

        /// <summary>
        /// Get all elements.
        /// </summary>
        /// <param name="predicate">query filters.</param>
        /// <param name="queryTracking">query tracking.</param>
        /// <returns>All elements in source.</returns>
        Task<IEnumerable<TEntity>> GetAsync(Expression<Func<TEntity, bool>> predicate, QueryTrackingBehavior queryTracking = QueryTrackingBehavior.NoTracking);

        /// <summary>
        /// Get all elements according to specified filters.
        /// </summary>
        /// <param name="predicate">query filters.</param>
        /// <param name="includes">query includes.</param>
        /// <param name="queryTracking">query tracking.</param>
        /// <returns>locator elements at source according to filters.</returns>
        Task<IEnumerable<TEntity>> GetAsync(Expression<Func<TEntity, bool>> predicate, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> includes, QueryTrackingBehavior queryTracking = QueryTrackingBehavior.NoTracking);

        /// <summary>
        /// Get all elements according to specified filters.
        /// </summary>
        /// <typeparam name="TResponse">response type.</typeparam>
        /// <param name="predicate">query filters.</param>
        /// <param name="includes">query includes.</param>
        /// <param name="fieldsSelect">query fields select.</param>
        /// <param name="queryTracking">query tracking.</param>
        /// <returns>locator elements at source according to filters.</returns>
        Task<IEnumerable<TResponse>> GetAsync<TResponse>(
            Expression<Func<TEntity, bool>> predicate = null,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> includes = null,
            Expression<Func<TEntity, TResponse>> fieldsSelect = null,
            QueryTrackingBehavior queryTracking = QueryTrackingBehavior.NoTracking);

        #endregion GetAsync

        #region GetOrdered

        /// <summary>
        /// Get all elements ordered according to specified filters.
        /// </summary>
        /// <typeparam name="TField">fields to orderby.</typeparam>
        /// <param name="orderByKeySelector">orderby clause.</param>
        /// <param name="orderAscending">type ordenation (asc, desc).</param>
        /// <param name="queryTracking">query tracking.</param>
        /// <returns>locator elements ordered at source according to filters.</returns>
        Task<IEnumerable<TEntity>> GetOrdered<TField>(Expression<Func<TEntity, TField>> orderByKeySelector, bool orderAscending, QueryTrackingBehavior queryTracking = QueryTrackingBehavior.NoTracking);

        /// <summary>
        /// Get all elements ordered according to specified filters.
        /// </summary>
        /// <typeparam name="TField">fields to orderby.</typeparam>
        /// <param name="predicate">query filters.</param>
        /// <param name="orderByKeySelector">orderby clause.</param>
        /// <param name="orderAscending">type ordenation (asc, desc).</param>
        /// <param name="queryTracking">query tracking.</param>
        /// <returns>locator elements ordered at source according to filters.</returns>
        Task<IEnumerable<TEntity>> GetOrdered<TField>(Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, TField>> orderByKeySelector, bool orderAscending, QueryTrackingBehavior queryTracking = QueryTrackingBehavior.NoTracking);

        /// <summary>
        /// Get all elements ordered according to specified filters.
        /// </summary>
        /// <typeparam name="TField">fields to orderby.</typeparam>
        /// <param name="predicate">query filters.</param>
        /// <param name="includes">query includes.</param>
        /// <param name="orderByKeySelector">orderby clause.</param>
        /// <param name="orderAscending">type ordenation (asc, desc).</param>
        /// <param name="queryTracking">query tracking.</param>
        /// <returns>locator elements ordered at source according to filters.</returns>
        Task<IEnumerable<TEntity>> GetOrdered<TField>(
            Expression<Func<TEntity, bool>> predicate,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> includes,
            Expression<Func<TEntity, TField>> orderByKeySelector,
            bool orderAscending,
            QueryTrackingBehavior queryTracking = QueryTrackingBehavior.NoTracking);

        /// <summary>
        /// Get all elements ordered according to specified filters.
        /// </summary>
        /// <typeparam name="TField">fields to orderby.</typeparam>
        /// <param name="predicate">query filters.</param>
        /// <param name="includes">query includes.</param>
        /// <param name="orderByKeySelector">orderby clause.</param>
        /// <param name="orderAscending">type ordenation (asc, desc).</param>
        /// <param name="take">number of fields to take.</param>
        /// <param name="queryTracking">query tracking.</param>
        /// <returns>locator elements ordered at source according to filters.</returns>
        Task<IEnumerable<TEntity>> GetOrdered<TField>(
            Expression<Func<TEntity, bool>> predicate = null,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> includes = null,
            Expression<Func<TEntity, TField>> orderByKeySelector = null,
            bool orderAscending = true,
            int? take = null,
            QueryTrackingBehavior queryTracking = QueryTrackingBehavior.NoTracking);

        /// <summary>
        /// Get all elements ordered according to specified filters.
        /// </summary>
        /// <typeparam name="TField">fields to orderby.</typeparam>
        /// <typeparam name="TResponse">response type.</typeparam>
        /// <param name="predicate">query filters.</param>
        /// <param name="includes">query includes.</param>
        /// <param name="fieldsSelect">query fields select.</param>
        /// <param name="orderByKeySelector">orderby clause.</param>
        /// <param name="orderAscending">type ordenation (asc, desc).</param>
        /// <param name="take">number of fields to take.</param>
        /// <param name="queryTracking">query tracking.</param>
        /// <returns>locator elements ordered at source according to filters.</returns>
        Task<IEnumerable<TResponse>> GetOrdered<TField, TResponse>(
            Expression<Func<TEntity, bool>> predicate = null,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> includes = null,
            Expression<Func<TEntity, TResponse>> fieldsSelect = null,
            Expression<Func<TEntity, TField>> orderByKeySelector = null,
            bool orderAscending = true,
            int? take = null,
            QueryTrackingBehavior queryTracking = QueryTrackingBehavior.NoTracking);

        #endregion GetOrdered

        /// <summary>
        /// Get the elements using pagination and sorted according to the specified filters.
        /// </summary>
        /// <typeparam name="TField">fields to orderby.</typeparam>
        /// <param name="predicate">query filters.</param>
        /// <param name="includes">query includes.</param>
        /// <param name="page">number of page.</param>
        /// <param name="pageSize">number of elements.</param>
        /// <param name="orderByKeySelector">orderby clause.</param>
        /// <param name="orderAscending">type ordenation (asc, desc).</param>
        /// <param name="queryTracking">query tracking.</param>
        /// <returns>locator elements paginated and ordered at source according to filters.</returns>
        Task<PaginatedList<TEntity>> GetPaginatedAsync<TField>(
            Expression<Func<TEntity, bool>> predicate,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> includes,
            int page,
            int pageSize,
            Expression<Func<TEntity, TField>> orderByKeySelector,
            bool orderAscending,
            QueryTrackingBehavior queryTracking = QueryTrackingBehavior.NoTracking);

        /// <summary>
        /// Get the elements using pagination and sorted according to the specified filters.
        /// </summary>
        /// <typeparam name="TField">fields to orderby.</typeparam>
        /// <typeparam name="TResponse">response type.</typeparam>
        /// <param name="predicate">query predicate.</param>
        /// <param name="includes">query includes.</param>
        /// <param name="fieldsSelect">query fields select.</param>
        /// <param name="page">number of page.</param>
        /// <param name="pageSize">number of elements.</param>
        /// <param name="orderByKeySelector">orderby clause.</param>
        /// <param name="orderAscending">type ordenation (asc, desc).</param>
        /// <param name="queryTracking">query tracking.</param>
        /// <returns>locator elements paginated and ordered at source according to filters.</returns>
        Task<PaginatedList<TResponse>> GetPaginatedAsync<TField, TResponse>(
            Expression<Func<TEntity, bool>> predicate = null,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> includes = null,
            Expression<Func<TEntity, TResponse>> fieldsSelect = null,
            int page = 0,
            int pageSize = 0,
            Expression<Func<TEntity, TField>> orderByKeySelector = null,
            bool orderAscending = true,
            QueryTrackingBehavior queryTracking = QueryTrackingBehavior.NoTracking);

        /// <summary>
        /// Get the elements using pagination and sorted according to the specified filters.
        /// </summary>
        /// <typeparam name="TField">fields to orderby.</typeparam>
        /// <typeparam name="TTargetEntity">Target entity.</typeparam>
        /// <param name="predicate">query predicate.</param>
        /// <param name="orderByKeySelector">orderby clause.</param>
        /// <param name="lastId">last register id.</param>
        /// <param name="lastIdOperator">operator used in last id condition..</param>
        /// <param name="pageSize">number of elements.</param>
        /// <param name="includes">query includes.</param>
        /// <param name="orderAscending">type ordenation (asc, desc).</param>
        /// <param name="queryTracking">query tracking.</param>
        /// <returns>locator elements paginated and ordered at source according to filters.</returns>
        Task<PaginatedList<TEntity>> GetPaginatedAsync<TField, TTargetEntity>(
            Expression<Func<TEntity, bool>> predicate,
            Expression<Func<TEntity, TField>> orderByKeySelector,
            int lastId,
            OperatorsSupportedPaging lastIdOperator,
            int pageSize,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> includes = null,
            bool orderAscending = true,
            QueryTrackingBehavior queryTracking = QueryTrackingBehavior.NoTracking)
            where TTargetEntity : class, IEntity;

        /// <summary>
        /// Get the elements using pagination and sorted according to the specified filters.
        /// </summary>
        /// <typeparam name="TField">fields to orderby.</typeparam>
        /// <typeparam name="TResponse">response type.</typeparam>
        /// <typeparam name="TTargetEntity">Target entity.</typeparam>
        /// <param name="predicate">query predicate.</param>
        /// <param name="fieldsSelect">query fields select.</param>
        /// <param name="orderByKeySelector">orderby clause.</param>
        /// <param name="lastId">last register id.</param>
        /// <param name="lastIdOperator">operator used in last id condition..</param>
        /// <param name="pageSize">number of elements.</param>
        /// <param name="includes">query includes.</param>
        /// <param name="orderAscending">type ordenation (asc, desc).</param>
        /// <param name="queryTracking">query tracking.</param>
        /// <returns>locator elements paginated and ordered at source according to filters.</returns>
        Task<PaginatedList<TResponse>> GetPaginatedAsync<TField, TResponse, TTargetEntity>(
            Expression<Func<TEntity, bool>> predicate,
            Expression<Func<TEntity, TResponse>> fieldsSelect,
            Expression<Func<TEntity, TField>> orderByKeySelector,
            int lastId,
            OperatorsSupportedPaging lastIdOperator,
            int pageSize,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> includes = null,
            bool orderAscending = true,
            QueryTrackingBehavior queryTracking = QueryTrackingBehavior.NoTracking)
            where TTargetEntity : class, IEntity;

        /// <summary>
        /// Add entity.
        /// </summary>
        /// <param name="entity">entity instance to add.</param>
        /// <param name="cancellationToken">cancellation token.</param>
        /// <returns>instance of entity included.</returns>
        Task<TEntity> AddAsync(TEntity entity, CancellationToken cancellationToken = default);

        /// <summary>
        /// Add entities.
        /// </summary>
        /// <param name="entities">collection of entities to add.</param>
        /// <param name="cancellationToken">cancellation token.</param>
        /// <returns>task.</returns>
        Task AddRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default);

        /// <summary>
        /// Remove entity.
        /// </summary>
        /// <param name="entity">instance of entity to remove.</param>
        void Remove(TEntity entity);

        /// <summary>
        /// Remove a list of entities.
        /// </summary>
        /// <param name="entities">list of entities to remove.</param>
        void RemoveRange(IEnumerable<TEntity> entities);

        /// <summary>
        /// Update entity.
        /// </summary>
        /// <param name="entity">entity of update.</param>
        /// <returns>return entity.</returns>
        TEntity Update(TEntity entity);

        /// <summary>
        /// Check if exists elements according to the criterion.
        /// </summary>
        /// <param name="predicate">query filter.</param>
        /// <param name="queryTracking">query tracking.</param>
        /// <returns>return exists elements for the filter.</returns>
        Task<bool> AnyAsync(Expression<Func<TEntity, bool>> predicate = null, QueryTrackingBehavior queryTracking = QueryTrackingBehavior.NoTracking);

        /// <summary>
        /// Get count of elements according to the criterion.
        /// </summary>
        /// <param name="predicate">query filter.</param>
        /// <param name="queryTracking">query tracking.</param>
        /// <returns>return the elements quantity for the filter.</returns>
        Task<int> CountAsync(Expression<Func<TEntity, bool>> predicate = null, QueryTrackingBehavior queryTracking = QueryTrackingBehavior.NoTracking);
    }
}
