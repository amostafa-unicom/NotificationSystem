using NotificationHubSystem.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace NotificationHubSystem.Infrastructure.Context
{
    public partial class AppDbContext
    {
        public void SingularizeTableNames(ModelBuilder modelBuilder)
        {
            foreach (IMutableEntityType entityType in modelBuilder.Model.GetEntityTypes())
                modelBuilder.Entity(entityType.ClrType).ToTable(entityType.ClrType.Name);
            EntityModelConfiguration(modelBuilder);
        }
        private void EntityModelConfiguration(ModelBuilder modelBuilder)
        {
        

            modelBuilder.Entity<NotificationBase>(entity =>
            {
                entity.Property(e => e.CreationDate).HasColumnType("datetime");
                entity.HasQueryFilter(e => e.DeleteStatus == SharedKernal.Enum.CommonEnum.DeleteStatus.NotDeleted); 
                entity.HasOne(e => e.SendingStatus).WithMany(e => e.NotificationBase).HasForeignKey(e => e.StatusId); 
                entity.HasOne(e => e.NotificationType).WithMany(e => e.NotificationBase).HasForeignKey(e => e.TypeId);
                entity.HasOne(e => e.Mail).WithOne(e => e.NotificationBase).HasForeignKey<Mail>(e => e.NotificationId);
                entity.HasOne(e => e.SMS).WithOne(e => e.NotificationBase).HasForeignKey<SMS>(e => e.NotificationId);
                entity.HasOne(e => e.PushNotification).WithOne(e => e.NotificationBase).HasForeignKey<PushNotification>(e => e.NotificationId);
            });

            modelBuilder.Entity<SendingStatus>(entity =>
            { 
                entity.Property(e => e.CreationDate).HasColumnType("datetime");
                entity.HasQueryFilter(e => e.DeleteStatus == SharedKernal.Enum.CommonEnum.DeleteStatus.NotDeleted);  
            });
        }
    }
}
