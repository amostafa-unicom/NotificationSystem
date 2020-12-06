namespace NotificationHubSystem.Core.Entities
{
    public class SMS
    {
        public int Id { get; set; }
        public int NotificationId { get; set; }
        public string Recipient { get; set; }
        public virtual NotificationBase NotificationBase { get; set; }
    }
}
