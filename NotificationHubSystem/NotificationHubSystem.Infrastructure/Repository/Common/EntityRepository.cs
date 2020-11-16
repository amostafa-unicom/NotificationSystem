using NotificationHubSystem.Core.Interfaces.Repository.Common;

namespace NotificationHubSystem.Infrastructure.Repository.Common
{
    internal class EntityRepository<T> : Repository<T>, IEntityRepository<T> where T : class
    {
        internal EntityRepository(Context.AppDbContext appDbContext) : base(appDbContext)
        { }
    }
}
