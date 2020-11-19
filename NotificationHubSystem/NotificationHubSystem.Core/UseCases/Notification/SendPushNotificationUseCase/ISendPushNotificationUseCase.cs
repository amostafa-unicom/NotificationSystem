using NotificationHubSystem.Core.Entities;
using NotificationHubSystem.SharedKernal;
using System;
using System.Collections.Generic;
using System.Text;

namespace NotificationHubSystem.Core.UseCases.Notification.SendPushNotificationUseCase
{
    public interface ISendPushNotificationUseCase : IUseCaseRequestResponseHandler<List<NotificationBase>, bool>
    {
    }
}
