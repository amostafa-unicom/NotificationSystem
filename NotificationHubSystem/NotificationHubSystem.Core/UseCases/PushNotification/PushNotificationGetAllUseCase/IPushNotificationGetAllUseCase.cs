using NotificationHubSystem.SharedKernal;

namespace NotificationHubSystem.Core.UseCases.PushNotification.PushNotificationGetAllUseCase
{
    public interface IPushNotificationGetAllUseCase : IUseCaseRequestResponseListHandler<PushNotificationGetAllInputDto, PushNotificationGetAllOutPutDto>
    {
    }
}
