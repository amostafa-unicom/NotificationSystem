namespace NotificationHubSystem.Core.UseCases.Notification.PushNotificationAddUseCase
{
    public class PushNotificationAddInputDto: BaseNotification
    {
        public string Title { get; set; }
        public string SendData { get; set; }
        public string NotificationTokenId { get; set; }
    }
}
