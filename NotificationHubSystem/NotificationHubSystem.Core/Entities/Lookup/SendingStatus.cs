using System.Collections.Generic;

namespace NotificationHubSystem.Core.Entities
{
    public class SendingStatus: BaseEntity<int>
    {
        public string Name { get; set; }
        public ICollection<NotificationBase> NotificationBase { get; set; }
    }
}
