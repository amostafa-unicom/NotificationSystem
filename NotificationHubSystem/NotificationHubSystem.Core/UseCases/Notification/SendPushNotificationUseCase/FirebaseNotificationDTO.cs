using System;
using System.Collections.Generic;
using System.Text;

namespace NotificationHubSystem.Core.UseCases.Notification.SendPushNotificationUseCase
{
    public class FirebaseNotificationDTO
    {
        public object Data { get; set; }
        public List<string> RegistrationIds { get; set; }
        public Notification Notification { get; set; }
    }

    public class Notification
    {
        public string Body { get; set; }
        public string Title { get; set; }
        public int Badge { get; set; }
        public string Sound { get; set; }
    }
}
