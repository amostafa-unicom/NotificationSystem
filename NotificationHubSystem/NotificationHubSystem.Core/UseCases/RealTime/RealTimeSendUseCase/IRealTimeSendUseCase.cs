using NotificationHubSystem.Core.Entities;
using NotificationHubSystem.SharedKernal;
using System.Collections.Generic;

namespace NotificationHubSystem.Core.UseCases.RealTime.RealTimeSendUseCase
{
    public interface IRealTimeSendUseCase : IUseCaseRequestResponseHandler<List<NotificationBase>, bool>
    {
    }
}
