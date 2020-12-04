using System.Collections.Generic;

namespace NotificationHubSystem.Core.UseCases.Notification.NotificationGetNewUseCase
{
    public class NotificationGetNewOutputDto
    {

        public List<Entities.PushNotification> PushNotification { get; set; }
    }

}
