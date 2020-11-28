using System;
using System.Collections.Generic;
using System.Text;

namespace NotificationHubSystem.Core.UseCases.Notification.PushNotificationGetAllUseCase
{
    public class PushNotificationGetAllInputDto
    {
        public int ReceiverId { get; set; }
        public int pageNumber { get; set; }
        public int PageSize { get; set; }
    }
}
