using NotificationHubSystem.SharedKernal;
using System.Collections.Generic;

namespace NotificationHubSystem.Core.UseCases.PushNotification.PushNotificationAddUseCase
{
    public interface IPushNotificationAddUseCase: IUseCaseRequestResponseHandler<List<PushNotificationAddInputDto>,bool>
    {
    }
}
