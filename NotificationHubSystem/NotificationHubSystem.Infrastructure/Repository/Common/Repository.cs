using NotificationHubSystem.Core.Interfaces.Repository.Common;
using NotificationHubSystem.Core.Interfaces.Repository.CRUD;
using NotificationHubSystem.Infrastructure.Context;
using NotificationHubSystem.Infrastructure.Repository.CRUD;
using NotificationHubSystem.SharedKernal.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace NotificationHubSystem.Infrastructure.Repository.Common
{
    internal abstract class Repository<T> : IRepository<T> where T : class
    {
        #region Properties
        public AppDbContext AppDbContext { get; }
        private ICreateRepository<T> CreateRepository { get; }
        private IUpdateRepository<T> UpdateRepository { get; }
        private IDeleteRepository<T> DeleteRepository { get; }
        private IRetrieveRepository<T> RetrieveRepository { get; }
        #endregion
        #region Constructor
        internal Repository(AppDbContext appDbContext)
        {
            AppDbContext = appDbContext;
            this.CreateRepository = new CreateRepository<T>(AppDbContext);
            this.UpdateRepository = new UpdateRepository<T>(AppDbContext);
            this.DeleteRepository = new DeleteRepository<T>(AppDbContext);
            this.RetrieveRepository = new RetrieveRepository<T>(AppDbContext);
        }
        #endregion
        #region Methods
        #region Create
        /// <summary>
        /// Insert a single object into the database.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>bool</returns>
        public async Task<bool> Insert(T entity)
        {
            return await CreateRepository.Insert(entity);
        }
        /// <summary>
        /// Insert a list of objects into the database.
        /// </summary>
        /// <param name="entityList"></param>
        public async Task<bool> Insert(List<T> entityList)
        {
            return await CreateRepository.Insert(entityList);
        }
        /// <summary>
        /// Insert a list of objects into the database as Bulk.
        /// </summary>
        /// <param name="entityList"></param>
        public async Task<bool> BulkInsert(List<T> entityList)
        {
            return await CreateRepository.Insert(entityList);
        }
        #endregion
        #region Update
        /// <summary>
        /// Update a single object in database.
        /// </summary>
        /// <param name="entity"></param>
        public async Task<bool> Update(T entity)
        {
            return await UpdateRepository.Update(entity);
        }
        /// <summary>
        /// Update a list of object in database.
        /// </summary>
        /// <param name="entityList"></param>
        public async Task<bool> Update(List<T> entityList)
        {
            return await UpdateRepository.Update(entityList);
        }
        #endregion
        #region Delete
        /// <summary>
        /// Delete single object from database.
        /// </summary>
        /// <param name="entity"></param>
        public async Task<bool> Delete(T entity)
        {
            return await DeleteRepository.Delete(entity);
        }
        /// <summary>
        /// Delete list of objects from database.
        /// </summary>
        /// <param name="entityList"></param>
        public async Task<bool> Delete(List<T> entityList)
        {
            return await DeleteRepository.Delete(entityList);
        }
        #endregion
        #region Retrieve
        /// <summary>
        /// Getting a set of data by given condition.
        /// </summary>
        /// <param name="filter"></param>
        /// <param name="includeProperties"></param>
        /// <returns>IQueryable<T></returns>
        public IQueryable<T> GetWhere(Expression<Func<T, bool>> filter, string includeProperties = "")
        {
            return RetrieveRepository.GetWhere(filter, includeProperties);
        }
        /// <summary>
        /// First Or Default Async
        /// </summary>
        /// <param name="filter"></param>
        /// <returns>Task<T></returns>
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
        /// Getting count.
        /// </summary>
        /// <param name="filter"></param>
        /// <param name="includeProperties"></param>
        /// <returns>List<T></returns>
        public async Task<int> GetCount(Expression<Func<T, bool>> filter, string includeProperties = "")
        {
            return await RetrieveRepository.GetCount(filter, includeProperties);
        }
        /// <summary>
        /// Getting Any
        /// </summary>
        /// <param name="filter"></param>
        /// <param name="includeProperties"></param>
        /// <returns>List<T></returns>
        public async Task<bool> GetAny(Expression<Func<T, bool>> filter, string includeProperties = "")
        {
            return await RetrieveRepository.GetAny(filter, includeProperties);
        }
        /// <summary>
        /// Getting an object.
        /// </summary>
        /// <param name="filter"></param>
        /// <param name="includeProperties"></param>
        /// <returns>T</returns>
        public async Task<T> Get(Expression<Func<T, bool>> filter, string includeProperties = "")
        {
            return await RetrieveRepository.Get(filter, includeProperties);
        }
        /// <summary>
        /// Getting all data.
        /// </summary>
        /// <param name="filter"></param>
        /// <param name="includeProperties"></param>
        /// <returns>List<T></returns>
        public async Task<List<T>> GetAll(Expression<Func<T, bool>> filter, string includeProperties = "", int takeCount = default)
        {
            return await RetrieveRepository.GetAll(filter, includeProperties, takeCount);
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
            return await RetrieveRepository.GetPage(skipCount, takeCount, filter, sortingExpression, sortDir, includeProperties);
        }
        #endregion
        #endregion
    }
}
