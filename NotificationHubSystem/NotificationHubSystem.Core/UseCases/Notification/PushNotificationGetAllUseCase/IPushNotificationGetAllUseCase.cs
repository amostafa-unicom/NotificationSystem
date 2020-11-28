using NotificationHubSystem.SharedKernal;

namespace NotificationHubSystem.Core.UseCases.Notification.PushNotificationGetAllUseCase
{
    public interface IPushNotificationGetAllUseCase : IUseCaseRequestResponseListHandler<PushNotificationGetAllInputDto, PushNotificationGetAllOutPutDto>
    {
    }
}
