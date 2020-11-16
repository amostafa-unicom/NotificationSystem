using NotificationHubSystem.Core.Interfaces.Repository.Custom;
using NotificationHubSystem.Core.Entities;
using NotificationHubSystem.Infrastructure.Context;
using NotificationHubSystem.Infrastructure.Repository.Common;

namespace NotificationHubSystem.Infrastructure.Repository.Custom
{
    internal class CityRepository : Repository<City>, ICityRepository
    {
        public CityRepository(AppDbContext appDbContext) : base(appDbContext)
        {
        }
    }
}
