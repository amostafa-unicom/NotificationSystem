using System;
using NotificationHubSystem.SharedKernal.Enum;

namespace NotificationHubSystem.Core.Entities
{
    public abstract class BaseEntity<TKeyType>
    {
        public TKeyType Id { get; set; }
        public CommonEnum.DeleteStatus DeleteStatus { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
