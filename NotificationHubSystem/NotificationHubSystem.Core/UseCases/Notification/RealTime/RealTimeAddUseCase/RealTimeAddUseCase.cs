using NotificationHubSystem.Core.Base;
using NotificationHubSystem.Core.Interfaces.Repository.Custom;
using NotificationHubSystem.SharedKernal;
using System;
using System.Threading.Tasks;
using static NotificationHubSystem.SharedKernal.Enum.CommonEnum;

namespace NotificationHubSystem.Core.UseCases.Notification.RealTime.RealTimeAddUseCase
{
    internal class RealTimeAddUseCase : BaseUseCase, IRealTimeAddUseCase
    {
        #region Props
        public INotificationBaseRepository NotificationBaseRepository { get; set; }
        #endregion
        public async Task<bool> HandleUseCase(RealTimeAddInputDto _request, IOutputPort<ResultDto<bool>> _response)
        {
            await NotificationBaseRepository.Insert(new Entities.NotificationBase
            {
                Body = _request.Body,
                ReceiverId = _request.ReceiverId,
                RealTime = new Entities.RealTime { Event = _request.Event },
                StatusId = (byte)SendingStatus.New,
                TypeId = (byte)NotificationType.RealTime,
                CreationDate = DateTime.UtcNow,
                DeleteStatus = (byte)DeleteStatus.NotDeleted
            });

            int result = await UnitOfWork.Commit();
            _response.HandlePresenter(new ResultDto<bool>(result > default(byte), result > default(byte)));

            return true;
        }
    }
}
