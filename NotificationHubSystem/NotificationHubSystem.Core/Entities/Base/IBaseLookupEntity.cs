namespace NotificationHubSystem.Core.Entities.Base
{
    public abstract class BaseLookupEntity<TKeyType> : BaseEntity<TKeyType>
    {
        public string Name { get; set; }
    }
}
