using NotificationHubSystem.Core.Interfaces.Repository.CRUD;
using NotificationHubSystem.SharedKernal.Enum;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace NotificationHubSystem.Infrastructure.Repository.CRUD
{
    internal class RetrieveRepository<T> : IRetrieveRepository<T> where T : class
    {
        #region Properties
        public Context.AppDbContext AppDbContext { get; }
        #endregion
        #region Constructor
        internal RetrieveRepository(Context.AppDbContext appDbContext)
        {
            this.AppDbContext = appDbContext;
        }
        #endregion
        #region Methods
        /// <summary>
        /// Getting a set of data by given condition.
        /// </summary>
        /// <param name="filter"></param>
        /// <param name="includeProperties"></param>
        /// <returns>IQueryable<T></returns>
        public IQueryable<T> GetWhere(Expression<Func<T, bool>> filter = null, string includeProperties = "")
        {
            IQueryable<T> query = AppDbContext.Set<T>();
            if (filter != null)
                query = query.Where(filter);
            query = includeProperties.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries).Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
            return query;
        }
        public async Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> filter)
        {
            IQueryable<T> query = AppDbContext.Set<T>();

            if (filter != null)
            {
                query = query.Where(filter);
            }
            return await query.FirstOrDefaultAsync();
        }
        /// <summary>
        /// Getting Any
        /// </summary>
        /// <param name="filter"></param>
        /// <param name="includeProperties"></param>
        /// <returns>List<T></returns>
        public async Task<bool> GetAny(Expression<Func<T, bool>> filter = null, string includeProperties = "")
        {
            IQueryable<T> query = AppDbContext.Set<T>();

            if (filter != null)
            {
                query = query.Where(filter);
            }

            query = includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                        .Aggregate(query, (current, includeProperty) => current.Include(includeProperty));

            return await query.AnyAsync();
        }
        /// <summary>
        /// Getting count.
        /// </summary>
        /// <param name="filter"></param>
        /// <param name="includeProperties"></param>
        /// <returns>List<T></returns>
        public async Task<int> GetCount(Expression<Func<T, bool>> filter = null, string includeProperties = "")
        {
            IQueryable<T> query = AppDbContext.Set<T>();

            if (filter != null)
            {
                query = query.Where(filter);
            }

            query = includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                        .Aggregate(query, (current, includeProperty) => current.Include(includeProperty));

            return await query.CountAsync();
        }
        /// <summary>
        /// Getting an object.
        /// </summary>
        /// <param name="filter"></param>
        /// <param name="includeProperties"></param>
        /// <returns>T</returns>
        public async Task<T> Get(Expression<Func<T, bool>> filter = null, string includeProperties = "")
        {
            IQueryable<T> query = AppDbContext.Set<T>();

            if (filter != null)
            {
                query = query.AsNoTracking().Where(filter);
            }

            query = includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                        .Aggregate(query, (current, includeProperty) => current.Include(includeProperty));

            return await query.FirstOrDefaultAsync();
        }
        /// <summary>
        /// Getting all data.
        /// </summary>
        /// <param name="filter"></param>
        /// <param name="includeProperties"></param>
        /// <param name="takeCount"></param>
        /// <returns>List<T></returns>
        public async Task<List<T>> GetAll(Expression<Func<T, bool>> filter = null, string includeProperties = "", int takeCount = default)
        {
            IQueryable<T> query = AppDbContext.Set<T>();

            if (filter != null)
            {
                query = takeCount > default(byte) ? query.Where(filter).Take(takeCount) : query.Where(filter);
            }

            query = includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                        .Aggregate(query, (current, includeProperty) => current.Include(includeProperty));

            return await query.ToListAsync();
        }
        /// <summary>
        /// Getting a set of data by given condition.
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <param name="skipCount"></param>
        /// <param name="takeCount"></param>
        /// <param name="filter"></param>
        /// <param name="sortingExpression"></param>
        /// <param name="sortDir"></param>
        /// <param name="includeProperties"></param>
        /// <returns>List<T></returns>
        public async Task<List<T>> GetPage<TKey>(int skipCount, int takeCount, Expression<Func<T, bool>> filter, Expression<Func<T, TKey>> sortingExpression, CommonEnum.SortDirection sortDir = CommonEnum.SortDirection.Ascending, string includeProperties = "")
        {
            IQueryable<T> query = AppDbContext.Set<T>().Where(filter);

            query = includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                .Aggregate(query, (current, includeProperty) => current.Include(includeProperty));

            switch (sortDir)
            {
                case CommonEnum.SortDirection.Ascending:
                    if (skipCount == 0)
                        query = query.OrderBy<T, TKey>(sortingExpression).Take(takeCount);
                    else
                        query = query.OrderBy<T, TKey>(sortingExpression).Skip(skipCount).Take(takeCount);
                    break;
                case CommonEnum.SortDirection.Descending:
                    if (skipCount == 0)
                        query = query.OrderByDescending<T, TKey>(sortingExpression).Take(takeCount);
                    else
                        query = query.OrderByDescending<T, TKey>(sortingExpression).Skip(skipCount).Take(takeCount);
                    break;
                default:
                    break;
            }
            return await query.ToListAsync();

        }
        #endregion
    }
}
