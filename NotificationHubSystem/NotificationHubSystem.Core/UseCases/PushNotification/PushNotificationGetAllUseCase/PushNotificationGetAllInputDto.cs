namespace NotificationHubSystem.Core.UseCases.PushNotification.PushNotificationGetAllUseCase
{
    public class PushNotificationGetAllInputDto
    {
        public int ReceiverId { get; set; }
        public int pageNumber { get; set; }
        public int PageSize { get; set; }
    }
}
