using NotificationHubSystem.Core.Base;
using NotificationHubSystem.Core.Entities;
using NotificationHubSystem.Core.Interfaces.Repository.Custom;
using NotificationHubSystem.SharedKernal;
using System.Collections.Generic;
using System.Threading.Tasks;
using static NotificationHubSystem.SharedKernal.Enum.CommonEnum;

namespace NotificationHubSystem.Core.UseCases.Notification.NotificationGetNewUseCase
{
    internal class NotificationGetNewUseCase : BaseUseCase, INotificationGetNewUseCase
    {
        public INotificationBaseRepository NotificationBaseRepository { get; set; }
        public async Task<bool> HandleUseCase(IOutputPort<ListResultDto<NotificationBase>> _response)
        {
            List<NotificationBase> notifications = await NotificationBaseRepository.GetAll(x => x.DeleteStatus == (byte)DeleteStatus.NotDeleted && x.StatusId == (byte)SharedKernal.Enum.CommonEnum.SendingStatus.New
            , $"{nameof(Mail)},{nameof(SMS)},{nameof(PushNotification)}");

            //if (notifications?.Any() ?? default)
            //{
            _response.HandlePresenter(new ListResultDto<NotificationBase>(new List<NotificationBase>(notifications), notifications.Count));
            //}else
            //    _response.HandlePresenter(new ResultDto<NotificationGetNewOutputDto>(default));
            return true;
        }

        //private NotificationGetNewOutputDto Mapping(List<NotificationBase> notifications)
        //{
        //    NotificationGetNewOutputDto result = new NotificationGetNewOutputDto();

        //    result.PushNotification = notifications.Where(p=>p.TypeId==(byte)SharedKernal.Enum.CommonEnum.NotificationType.PushNotification)?.Select(p => new PushNotification
        //    {
        //        Body = p.Body,
        //        NotificationId = p.Id,
        //        ReceiverId = p.ReceiverId,
        //        NotificationTokenId = p.PushNotification.NotificationTokenId,
        //        SendData = p.PushNotification.SendData,
        //        Title = p.PushNotification.Title
        //    }).ToList();

        //    return result;
        //}
    }
}
