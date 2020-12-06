using System.Net;

namespace NotificationHubSystem.Core.UseCases.PushNotification
{
    public class NotificationShared
    {
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
