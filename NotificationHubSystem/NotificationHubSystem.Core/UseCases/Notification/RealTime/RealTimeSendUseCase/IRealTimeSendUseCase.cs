using NotificationHubSystem.Core.Entities;
using NotificationHubSystem.SharedKernal;
using System.Collections.Generic;

namespace NotificationHubSystem.Core.UseCases.Notification.RealTime.RealTimeSendUseCase
{
    public interface IRealTimeSendUseCase : IUseCaseRequestResponseHandler<List<NotificationBase>, bool>
    {
    }
}
