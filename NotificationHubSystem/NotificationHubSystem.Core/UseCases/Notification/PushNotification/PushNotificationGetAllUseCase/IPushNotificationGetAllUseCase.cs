using NotificationHubSystem.SharedKernal;

namespace NotificationHubSystem.Core.UseCases.Notification.PushNotification.PushNotificationGetAllUseCase
{
    public interface IPushNotificationGetAllUseCase : IUseCaseRequestResponseListHandler<PushNotificationGetAllInputDto, PushNotificationGetAllOutPutDto>
    {
    }
}
