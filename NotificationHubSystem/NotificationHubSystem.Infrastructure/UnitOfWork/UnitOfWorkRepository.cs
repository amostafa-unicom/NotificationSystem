using NotificationHubSystem.Core.Entities;
using NotificationHubSystem.Core.Interfaces.Repository.Common;
using NotificationHubSystem.Infrastructure.Repository.Common;

namespace NotificationHubSystem.Infrastructure
{
    internal partial class UnitOfWork
    {
        public IEntityRepository<City> CityRepository => new EntityRepository<City>(AppDbContext);
    }
}
