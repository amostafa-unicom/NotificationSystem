using System.Collections.Generic;
using System.Threading.Tasks;

namespace NotificationHubSystem.Core.Interfaces.Repository.CRUD
{
    public interface IUpdateRepository<T> where T : class
    {
        Task<bool> Update(T entity);
        Task<bool> Update(List<T> entityList);
    }
}
