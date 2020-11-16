using NotificationHubSystem.Core.Interfaces.Repository.CRUD;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NotificationHubSystem.Infrastructure.Repository.CRUD
{
    internal class CreateRepository<T> : ICreateRepository<T> where T : class
    {
        #region Properties
        public Context.AppDbContext AppDbContext { get; }
        #endregion
        #region Constructor
        internal CreateRepository(Context.AppDbContext appDbContext)
        {
            this.AppDbContext = appDbContext;
        }
        #endregion
        #region Methods
        /// <summary>
        /// Insert a single object into the database.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>bool</returns>
        public async Task<bool> Insert(T entity)
        {
            await AppDbContext.Set<T>().AddAsync(entity);
            return true;
        }
        /// <summary>
        /// Insert a list of objects into the database.
        /// </summary>
        /// <param name="entityList"></param>
        public async Task<bool> Insert(List<T> entityList)
        {
            await AppDbContext.Set<T>().AddRangeAsync(entityList);
            return true;
        }
        #endregion
    }
}
