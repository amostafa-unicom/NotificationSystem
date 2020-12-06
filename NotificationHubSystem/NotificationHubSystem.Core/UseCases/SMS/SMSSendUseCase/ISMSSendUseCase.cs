using NotificationHubSystem.SharedKernal;
using System.Collections.Generic;

namespace NotificationHubSystem.Core.UseCases.SMS.SMSSendUseCase
{
    public interface ISMSSendUseCase : IUseCaseRequestResponseHandler<List<Entities.NotificationBase>, bool>
    {
    }
}
