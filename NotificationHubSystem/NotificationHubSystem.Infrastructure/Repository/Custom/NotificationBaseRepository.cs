using NotificationHubSystem.Core.Entities;
using NotificationHubSystem.Core.Interfaces.Repository.Custom;
using NotificationHubSystem.Infrastructure.Context;
using NotificationHubSystem.Infrastructure.Repository.Common;

namespace NotificationHubSystem.Infrastructure.Repository.Custom
{
    internal class NotificationBaseRepository:Repository<NotificationBase>, INotificationBaseRepository
    {
        public NotificationBaseRepository(AppDbContext appDbContext) : base(appDbContext)
        {
        }
    }
}
