using NotificationHubSystem.SharedKernal;
using System.Collections.Generic;

namespace NotificationHubSystem.Core.UseCases.Notification.PushNotificationAddUseCase
{
    public interface IPushNotificationAddUseCase: IUseCaseRequestResponseHandler<List<PushNotificationAddInputDto>,bool>
    {
    }
}
