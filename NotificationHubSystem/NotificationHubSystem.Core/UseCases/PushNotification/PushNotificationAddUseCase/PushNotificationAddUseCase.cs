using NotificationHubSystem.Core.Base;
using NotificationHubSystem.Core.Interfaces.Repository.Custom;
using NotificationHubSystem.SharedKernal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static NotificationHubSystem.SharedKernal.Enum.CommonEnum;

namespace NotificationHubSystem.Core.UseCases.PushNotification.PushNotificationAddUseCase
{
    internal class PushNotificationAddUseCase : BaseUseCase, IPushNotificationAddUseCase
    {
        public INotificationBaseRepository NotificationBaseRepository { get; set; }
        public async Task<bool> HandleUseCase(List<PushNotificationAddInputDto> _request, IOutputPort<ResultDto<bool>> _response)
        {
            await NotificationBaseRepository.Insert(_request.Select(p => new Entities.NotificationBase
            {
                ReceiverId = p.ReceiverId,
                Body = p.Body,
                CreationDate = DateTime.UtcNow,
                DeleteStatus = (byte)DeleteStatus.NotDeleted,
                PushNotification = new Entities.PushNotification { NotificationTokenId = p.NotificationTokenId, SendData = p.SendData, Title = p.Title },
                StatusId = (byte)SendingStatus.New,
                TypeId = (byte)NotificationType.PushNotification

            }).ToList());

            int result = await UnitOfWork.Commit();

            _response.HandlePresenter(new ResultDto<bool>(result > default(byte), result > default(byte)));
            return true;
        }
    }
}
