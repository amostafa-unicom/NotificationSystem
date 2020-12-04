namespace NotificationHubSystem.Core.Entities
{
    public class RealTime
    {
        public int Id { get; set; }
        public int NotificationId { get; set; }
        public string Event { get; set; }
        public virtual NotificationBase NotificationBase { get; set; }
    }
}
