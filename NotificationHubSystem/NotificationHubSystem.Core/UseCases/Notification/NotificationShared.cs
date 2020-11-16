using System;
using System.Collections.Generic;
using System.Text;

namespace NotificationHubSystem.Core.UseCases.Notification
{
    public class NotificationShared
    {
    }

    public class BaseNotification
    {
        public int ReceiverId { get; set; }
        public string Body { get; set; }
    }
}
