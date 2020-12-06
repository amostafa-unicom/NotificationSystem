using NotificationHubSystem.Core.DTOs.UseCase.Base;

namespace NotificationHubSystem.Core.UseCases.PushNotification.PushNotificationAddUseCase
{
    public class PushNotificationAddInputDto: NotificationBase
    {
        public string Title { get; set; }
        public string SendData { get; set; }
        public string NotificationTokenId { get; set; }
    }
}
