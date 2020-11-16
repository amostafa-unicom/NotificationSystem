using NotificationHubSystem.Core.Entities;
using NotificationHubSystem.SharedKernal.Enum;
using Microsoft.EntityFrameworkCore;
using System;

namespace NotificationHubSystem.Infrastructure.Context
{
    public static class EnumBuilder
    {
        #region Public - Methods
        public static void BuildEnums(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SendingStatus>().HasData(CreateSendingStatus(CommonEnum.SendingStatus.New));
            modelBuilder.Entity<SendingStatus>().HasData(CreateSendingStatus(CommonEnum.SendingStatus.Success));
            modelBuilder.Entity<SendingStatus>().HasData(CreateSendingStatus(CommonEnum.SendingStatus.Failed)); 
            
            modelBuilder.Entity<NotificationType>().HasData(CreateNotificatioType(CommonEnum.NotificationType.Mail));
            modelBuilder.Entity<NotificationType>().HasData(CreateNotificatioType(CommonEnum.NotificationType.PushNotification));
            modelBuilder.Entity<NotificationType>().HasData(CreateNotificatioType(CommonEnum.NotificationType.SMS));
        }
        #endregion

        #region Private - Methods
        private static SendingStatus CreateSendingStatus(CommonEnum.SendingStatus sendingStatus)
        {
            return new SendingStatus
            {
                Id = (int)sendingStatus,
                Name = sendingStatus.ToString(),
                DeleteStatus = CommonEnum.DeleteStatus.NotDeleted,
                CreationDate = DateTime.Now
            };
        }

        private static NotificationType CreateNotificatioType(CommonEnum.NotificationType NotificationType)
        {
            return new NotificationType
            {
                Id = (int)NotificationType,
                Name = NotificationType.ToString(),
                DeleteStatus = CommonEnum.DeleteStatus.NotDeleted,
                CreationDate = DateTime.Now
            };
        }
        #endregion
    }
}
