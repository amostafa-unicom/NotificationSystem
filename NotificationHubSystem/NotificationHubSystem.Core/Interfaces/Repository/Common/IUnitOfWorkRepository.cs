using NotificationHubSystem.Core.Entities;

namespace NotificationHubSystem.Core.Interfaces.Repository.Common
{
    public partial interface IUnitOfWork
    {
        IEntityRepository<City> CityRepository { get; }
    }
}
