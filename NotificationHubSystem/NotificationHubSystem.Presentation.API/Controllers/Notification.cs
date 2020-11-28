using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NotificationHubSystem.Core.UseCases.Notification.PushNotificationAddUseCase;
using NotificationHubSystem.Core.UseCases.Notification.PushNotificationGetAllUseCase;
using NotificationHubSystem.SharedKernal;
using NotificationHubSystem.SharedKernal.AppConfiguration.Base;
using NotificationHubSystem.SharedKernal.Helper.HttpInOutHandler;
using NotificationHubSystem.SharedKernal.Helper.Pagination;

namespace NotificationHubSystem.Presentation.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class Notification : BaseController
    {
        #region Properties
        public IPushNotificationAddUseCase PushNotificationAddUseCase { get; set; }
        public IPushNotificationGetAllUseCase PushNotificationGetAllUseCase { get; set; }
        #endregion

        #region Actions
        [HttpPost]
        public async Task<ActionResult<ResultDto<bool>>> AddPushNotification([FromBody]List<PushNotificationAddInputDto> request)
        {
            OutputPort<ResultDto<bool>> presenter = new OutputPort<ResultDto<bool>>();
             await PushNotificationAddUseCase.HandleUseCase(request, presenter);

            return presenter.Result;
        }

        [HttpPost]
        public async Task<ActionResult<ListResultDto<PushNotificationGetAllOutPutDto>>> GetAllushNotification([FromBody]PushNotificationGetAllInputDto request)
        {
            OutputPort<ListResultDto<PushNotificationGetAllOutPutDto>> presenter = new OutputPort<ListResultDto<PushNotificationGetAllOutPutDto>>();
            await PushNotificationGetAllUseCase.HandleUseCase(request, presenter);

            return presenter.Result;
        }

        #endregion
    }
}
