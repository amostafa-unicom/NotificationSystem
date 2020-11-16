using NotificationHubSystem.SharedKernal.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace NotificationHubSystem.Core.Interfaces.Repository.CRUD
{
    public interface IRetrieveRepository<T> where T : class
    {
        IQueryable<T> GetWhere(Expression<Func<T, bool>> filter = null, string includeProperties = "");
        Task<int> GetCount(Expression<Func<T, bool>> filter = null, string includeProperties = "");
        Task<bool> GetAny(Expression<Func<T, bool>> filter = null, string includeProperties = "");
        Task<T> Get(Expression<Func<T, bool>> filter = null, string includeProperties = "");
        Task<List<T>> GetAll(Expression<Func<T, bool>> filter = null, string includeProperties = "", int takeCount = default);
        Task<List<T>> GetPage<TKey>(int skipCount, int takeCount, Expression<Func<T, bool>> filter, Expression<Func<T, TKey>> sortingExpression = null, CommonEnum.SortDirection sortDir = CommonEnum.SortDirection.Ascending, string includeProperties = "");
    }
}
