using NotificationHubSystem.Core.Base;
using NotificationHubSystem.Core.Interfaces.Repository.Custom;
using NotificationHubSystem.SharedKernal;
using System;
using System.Threading.Tasks;
using static NotificationHubSystem.SharedKernal.Enum.CommonEnum;

namespace NotificationHubSystem.Core.UseCases.SMS.SMSAddUseCase
{
    internal class SMSAddUseCase : BaseUseCase, ISMSAddUseCase
    {
        public INotificationBaseRepository NotificationBaseRepository { get; set; }
        public async Task<bool> HandleUseCase(SMSAddInputDto _request, IOutputPort<ResultDto<bool>> _response)
        {
            await NotificationBaseRepository.Insert(new Entities.NotificationBase
            {
                Body = _request.Body,
                ReceiverId = _request.ReceiverId,
                SMS = new Entities.SMS { Recipient = _request.Recipient },
                StatusId = (byte)SendingStatus.New,
                TypeId = (byte)NotificationType.SMS,
                CreationDate = DateTime.UtcNow,
                DeleteStatus = (byte)DeleteStatus.NotDeleted
            });

            int result = await UnitOfWork.Commit();
            _response.HandlePresenter(new ResultDto<bool>(result > default(byte), result > default(byte)));
            return true;
        }
    }
}
