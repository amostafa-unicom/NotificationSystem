using NotificationHubSystem.Core.Base;
using NotificationHubSystem.Core.Entities;
using NotificationHubSystem.Core.Interfaces.Repository.Custom;
using NotificationHubSystem.SharedKernal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using static NotificationHubSystem.SharedKernal.Enum.CommonEnum;

namespace NotificationHubSystem.Core.UseCases.Notification.PushNotificationGetAllUseCase
{
    internal class PushNotificationGetAllUseCase : BaseUseCase, IPushNotificationGetAllUseCase
    {
        #region Props
        public INotificationBaseRepository NotificationBaseRepository { get; set; }
        #endregion
        public async Task<bool> HandleUseCase(PushNotificationGetAllInputDto request, IOutputPort<ListResultDto<PushNotificationGetAllOutPutDto>> outputPort)
        {
            Expression<Func<NotificationBase, int>> sortingExpression = x => x.Id;
            int count = await NotificationBaseRepository.GetCount(x => x.DeleteStatus == (byte)DeleteStatus.NotDeleted && x.ReceiverId==request.ReceiverId);
            List<NotificationBase> notifications = await NotificationBaseRepository.GetPage(request.pageNumber, request.PageSize, x => x.DeleteStatus == (byte)DeleteStatus.NotDeleted && x.ReceiverId == request.ReceiverId, sortingExpression, SortDirection.Descending, $"{nameof(PushNotification)}");

            outputPort.HandlePresenter(new ListResultDto<PushNotificationGetAllOutPutDto>(Mapping(notifications), count, true));
            return true;
        }
        private List<PushNotificationGetAllOutPutDto> Mapping(List<NotificationBase> notifications)
        {
            List<PushNotificationGetAllOutPutDto> result = new List<PushNotificationGetAllOutPutDto>();
            if (notifications?.Any() ?? default)
                result = notifications.Select(x => new PushNotificationGetAllOutPutDto { Title = x.PushNotification.Title, Body = x.Body }).ToList();
            return result;
        }
    }
}
