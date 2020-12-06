using NotificationHubSystem.Core.Entities;
using NotificationHubSystem.SharedKernal;
using System.Collections.Generic;

namespace NotificationHubSystem.Core.UseCases.PushNotification.SendPushNotificationUseCase
{
    public interface ISendPushNotificationUseCase : IUseCaseRequestResponseHandler<List<NotificationBase>, bool>
    {
    }
}
