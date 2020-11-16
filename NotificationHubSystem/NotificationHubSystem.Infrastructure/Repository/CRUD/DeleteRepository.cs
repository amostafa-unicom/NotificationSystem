using NotificationHubSystem.Core.Interfaces.Repository.CRUD;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NotificationHubSystem.Infrastructure.Repository.CRUD
{
    internal class DeleteRepository<T> : IDeleteRepository<T> where T : class
    {
        #region Properties
        public Context.AppDbContext AppDbContext { get; }
        #endregion
        #region Constructor
        internal DeleteRepository(Context.AppDbContext appDbContext)
        {
            this.AppDbContext = appDbContext;
        }
        #endregion
        #region Methods
        /// <summary>
        /// Delete single object from database.
        /// </summary>
        /// <param name="entity"></param>
        public async Task<bool> Delete(T entity)
        {
            await Task.Run(() => AppDbContext.Set<T>().Remove(entity));
            return true;
        }
        /// <summary>
        /// Delete list of objects from database.
        /// </summary>
        /// <param name="entityList"></param>
        public async Task<bool> Delete(List<T> entityList)
        {
            await Task.Run(() => AppDbContext.Set<T>().RemoveRange(entityList));
            return true;
        }
        #endregion
    }
}
