using NotificationHubSystem.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace NotificationHubSystem.Infrastructure.Context
{
    public partial class AppDbContext
    { 
        public virtual DbSet<NotificationBase> NotificationBase { get; set; }
        public virtual DbSet<SMS> SMS { get; set; }
        public virtual DbSet<PushNotification> PushNotification { get; set; } 
        public virtual DbSet<SendingStatus> SendingStatus { get; set; } 
        public virtual DbSet<NotificationType> NotificationType { get; set; }  

    }
}
