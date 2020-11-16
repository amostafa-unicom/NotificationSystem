namespace NotificationHubSystem.Core.Entities
{
    public class PushNotification
    {
        public int Id { get; set; }
        public int NotificationId { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public string SendData { get; set; }
        public string NotificationTokenId { get; set; }
        public virtual NotificationBase NotificationBase { get; set; }
    }
}
