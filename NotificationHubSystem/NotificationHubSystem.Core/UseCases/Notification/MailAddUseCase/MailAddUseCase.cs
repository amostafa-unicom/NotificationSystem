using NotificationHubSystem.Core.Base;
using NotificationHubSystem.SharedKernal;
using System;
using System.Threading.Tasks;

namespace NotificationHubSystem.Core.UseCases.Notification.MailAddUseCase
{
    internal class MailAddUseCase : BaseUseCase, IMailAddUseCase
    {
        public Task<bool> HandleUseCase(MailAddInputDto _request, IOutputPort<ResultDto<bool>> _response)
        {
            throw new NotImplementedException();
        }
    }
}
