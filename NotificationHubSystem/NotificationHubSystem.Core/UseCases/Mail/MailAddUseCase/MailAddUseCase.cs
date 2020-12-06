using NotificationHubSystem.Core.Base;
using NotificationHubSystem.Core.Interfaces.Repository.Custom;
using NotificationHubSystem.SharedKernal;
using System;
using System.Linq;
using System.Threading.Tasks;
using static NotificationHubSystem.SharedKernal.Enum.CommonEnum;

namespace NotificationHubSystem.Core.UseCases.MailAddUseCase
{
    internal class MailAddUseCase : BaseUseCase, IMailAddUseCase
    {
        public INotificationBaseRepository NotificationBaseRepository { get; set; }
        public async Task<bool> HandleUseCase(MailAddInputDto _request, IOutputPort<ResultDto<bool>> _response)
        {
            await NotificationBaseRepository.Insert(new Entities.NotificationBase
            {
                ReceiverId = _request.ReceiverId,
                Body = _request.Body,
                CreationDate = DateTime.UtcNow,
                DeleteStatus = (byte)DeleteStatus.NotDeleted,
                Mail = new Entities.Mail
                {
                    IsHtml = _request.IsHtml,
                    CC = _request.Cc?.Any() ?? default ? string.Join(",", _request.Cc) : default,
                    BCC = _request.Bcc?.Any() ?? default ? string.Join(",", _request.Bcc) : default,
                    To = _request.To?.Any() ?? default ? string.Join(",", _request.To) : default,
                    Subject = _request.Subject
                },
                StatusId = (byte)SendingStatus.New,
                TypeId = (byte)NotificationType.Mail

            });

            int result = await UnitOfWork.Commit();

            _response.HandlePresenter(new ResultDto<bool>(result > default(byte), result > default(byte)));

            return true;
        }

    }
}
