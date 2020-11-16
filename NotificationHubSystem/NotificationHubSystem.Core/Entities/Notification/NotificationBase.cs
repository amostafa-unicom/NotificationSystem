namespace NotificationHubSystem.Core.Entities
{
    public class NotificationBase : BaseEntity<int>
    {
        public int ReceiverId { get; set; }
        public int TypeId { get; set; }
        public int StatusId { get; set; }
        public string Body { get; set; }
        public string Exception { get; set; } 
        public virtual Mail Mail { get; set; }
        public virtual SMS SMS { get; set; }
        public virtual SendingStatus SendingStatus { get; set; }
        public virtual PushNotification PushNotification { get; set; }
        public virtual NotificationType NotificationType { get; set; } 

    }
}
