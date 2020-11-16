using System;
using System.Threading.Tasks;

namespace NotificationHubSystem.Core.Interfaces.Repository.Common
{
    public partial interface IUnitOfWork : IDisposable
    {
        Task<int> Commit();
        Task<bool> Transaction(Action action);
    }
}
