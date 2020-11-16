using System.Collections.Generic;
using System.Threading.Tasks;

namespace NotificationHubSystem.Core.Interfaces.Repository.CRUD
{
    public interface ICreateRepository<T> where T : class
    {
        Task<bool> Insert(T entity);
        Task<bool> Insert(List<T> entityList);
    }
}
