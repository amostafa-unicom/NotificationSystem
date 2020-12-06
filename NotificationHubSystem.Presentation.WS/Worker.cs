using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NotificationHubSystem.Core.Entities;
using NotificationHubSystem.Core.UseCases.Mail.MailSendUseCase;
using NotificationHubSystem.Core.UseCases.NotificationGetNewUseCase;
using NotificationHubSystem.Core.UseCases.PushNotification.SendPushNotificationUseCase;
using NotificationHubSystem.Core.UseCases.RealTime.RealTimeSendUseCase;
using NotificationHubSystem.Core.UseCases.SMS.SMSSendUseCase;
using NotificationHubSystem.SharedKernal;
using NotificationHubSystem.SharedKernal.Enum;
using NotificationHubSystem.SharedKernal.Settings;

namespace NotificationHubSystem.Presentation.WS
{
    public class Worker : BackgroundService
    {
        #region Properties
        //private readonly ILogger<Worker> _logger;
        //private readonly IServiceScopeFactory _serviceScopeFactory;
        private WorkerSettings Setting { get; }
        private IServiceProvider Services { get; }
        #endregion

        #region Constructor
        /// <summary>
        /// MailWorkerService constructor used to resolve the needed objects by DI.
        /// </summary>
        /// <param name="services">Background serivce provider.</param>
        public Worker(WorkerSettings settings, IServiceProvider services)
        {
            this.Services = services;
            this.Setting = settings;
        }
        #endregion

        //public Worker(ILogger<Worker> logger, IServiceScopeFactory serviceScopeFactory)
        //{
        //    _logger = logger;
        //    _serviceScopeFactory = serviceScopeFactory;
        //}

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                await DoWork();
                await Task.Delay(Setting.WorkingInterval, stoppingToken);
            }
        }

        #region Methods
        /// <summary>
        /// Get New Notifications
        /// </summary>
        private async Task DoWork()
        {
            IServiceScope scope = Services.CreateScope();
            NotificationHubSystem.SharedKernal.Helper.SystemLogger.ILogger logger = scope.ServiceProvider.GetRequiredService<NotificationHubSystem.SharedKernal.Helper.SystemLogger.ILogger>();
            try
            {
                await logger.WriteLogAsync(CommonEnum.LogLevelEnum.Information, MethodBase.GetCurrentMethod(), $"Worker running at: [{DateTimeOffset.Now}]");
                INotificationGetNewUseCase notificationGetNewUseCase = scope.ServiceProvider.GetRequiredService<INotificationGetNewUseCase>();
                OutputPort<ListResultDto<NotificationBase>> result = new OutputPort<ListResultDto<NotificationBase>>();
                await notificationGetNewUseCase.HandleUseCase(result);
                if (result.Result.Data != default)
                    await HandleNotification(result.Result.Data, scope);

            }
            catch (Exception exception)
            {
                await logger.WriteLogAsync(CommonEnum.LogLevelEnum.Error, MethodBase.GetCurrentMethod(), exception: exception);
            }
        }

        /// <summary>
        /// Handle notification
        /// </summary>
        /// <returns></returns>
        private async Task<bool> HandleNotification(List<NotificationBase> Notification, IServiceScope scope)
        {
            OutputPort<ResultDto<bool>> result = new OutputPort<ResultDto<bool>>();

            #region Push Notification
            ISendPushNotificationUseCase sendPushNotificationUseCase = scope.ServiceProvider.GetRequiredService<ISendPushNotificationUseCase>();
            List<NotificationBase> PushNotification = Notification.Where(x => x.TypeId == (byte)CommonEnum.NotificationType.PushNotification).ToList();
            if (PushNotification?.Any() ?? default)
                await sendPushNotificationUseCase.HandleUseCase(PushNotification, result);
            #endregion

            #region RealTime
            IRealTimeSendUseCase sendRealTimeNotificationUseCase = scope.ServiceProvider.GetRequiredService<IRealTimeSendUseCase>();
            List<NotificationBase> RealTimeNotification = Notification.Where(x => x.TypeId == (byte)CommonEnum.NotificationType.RealTime).ToList();
            if (RealTimeNotification?.Any() ?? default)
                await sendRealTimeNotificationUseCase.HandleUseCase(RealTimeNotification, result);
            #endregion

            #region Mail
            IMailSendUseCase MailSendUseCase = scope.ServiceProvider.GetRequiredService<IMailSendUseCase>();
            List<NotificationBase> MailNotification = Notification.Where(x => x.TypeId == (byte)CommonEnum.NotificationType.Mail).ToList();
            if (MailNotification?.Any() ?? default)
                await MailSendUseCase.HandleUseCase(MailNotification, result);
            #endregion

            #region SMS
            ISMSSendUseCase SMSSendUseCase = scope.ServiceProvider.GetRequiredService<ISMSSendUseCase>();
            List<NotificationBase> SMSNotification = Notification.Where(x => x.TypeId == (byte)CommonEnum.NotificationType.SMS).ToList();
            if (SMSNotification?.Any() ?? default)
                await SMSSendUseCase    .HandleUseCase(SMSNotification, result);
            #endregion

            return true;
        }
        #endregion



    }
}
