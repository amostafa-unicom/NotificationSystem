using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NotificationHubSystem.Core.Interfaces.Repository.Custom;
using NotificationHubSystem.Core.UseCases.MailAddUseCase;
using NotificationHubSystem.Core.UseCases.PushNotification.PushNotificationAddUseCase;
using NotificationHubSystem.Core.UseCases.PushNotification.PushNotificationGetAllUseCase;
using NotificationHubSystem.Core.UseCases.RealTime.RealTimeAddUseCase;
using NotificationHubSystem.Core.UseCases.SMS.SMSAddUseCase;
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
        public IRealTimeAddUseCase RealTimeAddUseCase { get; set; }
        public IMailAddUseCase MailAddUseCase { get; set; }
        public ISMSAddUseCase SMSAddUseCase { get; set; }
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
        public async Task<ActionResult<ResultDto<bool>>> AddRealTimeNotification([FromBody]RealTimeAddInputDto request)
        {
            OutputPort<ResultDto<bool>> presenter = new OutputPort<ResultDto<bool>>();
            await RealTimeAddUseCase.HandleUseCase(request, presenter);

            return presenter.Result;
        }

        [HttpPost]
        public async Task<ActionResult<ResultDto<bool>>> AddMail([FromBody]MailAddInputDto request)
        {
            OutputPort<ResultDto<bool>> presenter = new OutputPort<ResultDto<bool>>();
            await MailAddUseCase.HandleUseCase(request, presenter);

            return presenter.Result;
        }


        [HttpPost]
        public async Task<ActionResult<ResultDto<bool>>> AddSMS([FromBody]SMSAddInputDto request)
        {
            OutputPort<ResultDto<bool>> presenter = new OutputPort<ResultDto<bool>>();
            await SMSAddUseCase.HandleUseCase(request, presenter);

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
