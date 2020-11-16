using NotificationHubSystem.Core.Interfaces.Repository.CRUD;

namespace NotificationHubSystem.Core.Interfaces.Repository.Common
{
    public interface IRepository<T> : IRetrieveRepository<T>, ICreateRepository<T>, IUpdateRepository<T> /*, IDeleteRepository<T>,*/  where T : class
    {
    }
}
