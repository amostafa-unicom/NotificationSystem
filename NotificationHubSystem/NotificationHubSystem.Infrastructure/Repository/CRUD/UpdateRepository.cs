using NotificationHubSystem.Core.Interfaces.Repository.CRUD;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NotificationHubSystem.Infrastructure.Repository.CRUD
{
    internal class UpdateRepository<T> : IUpdateRepository<T> where T : class
    {
        #region Properties
        public Context.AppDbContext AppDbContext { get; }
        #endregion
        #region Constructor
        internal UpdateRepository(Context.AppDbContext appDbContext)
        {
            this.AppDbContext = appDbContext;
        }
        #endregion
        #region Methods
        /// <summary>
        /// Update a single object in database.
        /// </summary>
        /// <param name="entity"></param>
        public async Task<bool> Update(T entity)
        {
            await Task.Run(() => AppDbContext.Set<T>().Update(entity));
            return true;
        }
        /// <summary>
        /// Update a list of object in database.
        /// </summary>
        /// <param name="entityList"></param>
        public async Task<bool> Update(List<T> entityList)
        {
            await Task.Run(() => AppDbContext.Set<T>().UpdateRange(entityList));
            return true;
        }
        #endregion
    }
}
