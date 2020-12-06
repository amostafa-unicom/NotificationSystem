namespace NotificationHubSystem.Core.Entities
{
    public class Mail
    {
        public int Id { get; set; }
        public int NotificationId { get; set; }
        public bool IsHtml { get; set; }
        public string To { get; set; }
        public string CC { get; set; }
        public string BCC { get; set; }
        public string Subject { get; set; }
        public virtual NotificationBase NotificationBase { get; set; }

    }
}
