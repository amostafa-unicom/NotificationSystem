using System;
using System.Collections.Generic;
using System.Net;
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
    public class PushNotification
    {
        public int NotificationId { get; set; }
        public int ReceiverId { get; set; }
        public string Body { get; set; }
        public string Title { get; set; }
        public string SendData { get; set; }
        public string NotificationTokenId { get; set; }
    }
    internal class HTTPResponse
    {
        public HttpStatusCode HttpStatusCode { get; set; }
        public SharedKernal.Enum.CommonEnum.SendingStatus Status { get; set; }
        public string Body { get; set; }
    }
}
