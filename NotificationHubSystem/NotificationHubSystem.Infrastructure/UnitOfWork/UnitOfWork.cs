using NotificationHubSystem.Core.Interfaces.Repository.Common;
using NotificationHubSystem.Infrastructure.Context;
using NotificationHubSystem.SharedKernal.Enum;
using NotificationHubSystem.SharedKernal.Helper.SystemLogger;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace NotificationHubSystem.Infrastructure
{
    internal partial class UnitOfWork : IUnitOfWork
    {
        protected ILogger Logger { get; }
        public AppDbContext AppDbContext { get; }

        public UnitOfWork(AppDbContext appContext, ILogger logger)
        {
            AppDbContext = appContext;
            Logger = logger;
        }

        public async Task<int> Commit()
        {
            int commitCount = default;
            try
            {
                SetAudit();
                commitCount = await AppDbContext.SaveChangesAsync();
            }
            catch (Exception exception)
            {
                AppDbContext.ChangeTracker.Entries().ToList().ForEach(x => x.Reload());
                Logger.WriteLog(logType: CommonEnum.LogLevelEnum.Error, MethodBase.GetCurrentMethod(), exception: exception);
            }
            return commitCount;
        }
        public async Task<bool> Transaction(Action action)
        {
            bool isCommitted = default;
            Microsoft.EntityFrameworkCore.Storage.IDbContextTransaction transaction = null;
            try
            {
                transaction = AppDbContext.Database.BeginTransaction();
                action.Invoke();
                SetAudit();
                await transaction.CommitAsync();
            }
            catch (Exception exception)
            {
                await transaction.RollbackAsync();
                Logger.WriteLog(logType: CommonEnum.LogLevelEnum.Error, MethodBase.GetCurrentMethod(), exception: exception);
            }
            return isCommitted;
        }
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
        private void SetAudit()
        {
            #region Get all entities has modified or added
            List<EntityEntry<Core.Entities.BaseEntity<int>>> entites_int = AppDbContext.ChangeTracker.Entries<Core.Entities.BaseEntity<int>>().Where(entity => entity.State == EntityState.Added || entity.State == EntityState.Modified).ToList();
            List<EntityEntry<Core.Entities.BaseEntity<long>>> entites_long = AppDbContext.ChangeTracker.Entries<Core.Entities.BaseEntity<long>>().Where(entity => entity.State == EntityState.Added || entity.State == EntityState.Modified).ToList();
            #endregion
            #region ForEach loop for all entities by keys <int, long>
            entites_int.ForEach(entity =>
            {
                switch (entity.State)
                {
                    case EntityState.Added:
                        entity.Entity.CreationDate = DateTime.Now;
                        entity.Entity.DeleteStatus = CommonEnum.DeleteStatus.NotDeleted;
                        break;

                    case EntityState.Modified:

                        break;
                }
            });

            entites_long.ForEach(entity =>
            {
                switch (entity.State)
                {
                    case EntityState.Added:
                        entity.Entity.CreationDate = DateTime.Now;
                        entity.Entity.DeleteStatus = CommonEnum.DeleteStatus.NotDeleted;
                        break;

                    case EntityState.Modified:

                        break;
                }
            });

            #endregion
        }
    }
}
