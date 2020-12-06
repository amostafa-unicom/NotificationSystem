using NotificationHubSystem.SharedKernal;
using System.Collections.Generic;

namespace NotificationHubSystem.Core.UseCases.Mail.MailSendUseCase
{
    public interface IMailSendUseCase : IUseCaseRequestResponseHandler<List<Entities.NotificationBase>, bool>
    {
    }
}
