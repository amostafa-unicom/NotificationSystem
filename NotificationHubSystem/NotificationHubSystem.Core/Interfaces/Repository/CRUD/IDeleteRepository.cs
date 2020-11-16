using System.Collections.Generic;
using System.Threading.Tasks;

namespace NotificationHubSystem.Core.Interfaces.Repository.CRUD
{
    public interface IDeleteRepository<T> where T : class
    {
        Task<bool> Delete(T entity);
        Task<bool> Delete(List<T> entityList);
    }
}
