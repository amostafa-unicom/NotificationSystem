using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NotificationHubSystem.Core.DTOs.UseCase.City;
using NotificationHubSystem.Core.Interfaces.UseCase;
using NotificationHubSystem.SharedKernal.AppConfiguration.Serialization;
using NotificationHubSystem.SharedKernal.Enum;
using NotificationHubSystem.SharedKernal.Helper.HttpInOutHandler;
using NotificationHubSystem.SharedKernal.Helper.Pagination;
using NotificationHubSystem.SharedKernal.Helper.SystemLogger;
using NotificationHubSystem.SharedKernal.Settings;

namespace NotificationHubSystem.Presentation.MailSender
{
    public class Worker : BackgroundService
    {
        #region Properties
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
        #region Execute
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                await DoWork();
                await Task.Delay(Setting.WorkingInterval, stoppingToken);
            }
        }
        #endregion
        #region Methods
        /// <summary>
        /// Send the mails.
        /// </summary>
        private async Task DoWork()
        {
            IServiceScope scope = Services.CreateScope();
            ILogger logger = scope.ServiceProvider.GetRequiredService<ILogger>();
            try
            {
                ICityUseCase cityUseCase = scope.ServiceProvider.GetRequiredService<ICityUseCase>();
                await logger.WriteLogAsync(CommonEnum.LogLevelEnum.Information, MethodBase.GetCurrentMethod(), $"Worker running at: [{DateTimeOffset.Now}]");
                BaseResponseDto<PageList<CityDto>> cities = await cityUseCase.GetAll(new BaseRequestDto<SearchCityDto> { Data = new SearchCityDto { PageSize = Setting.TakeCount } });
                await logger.WriteLogAsync(CommonEnum.LogLevelEnum.Information, MethodBase.GetCurrentMethod(), $"Cities: [{JsonHandler.Serialize(cities)}]");
            }
            catch (Exception exception)
            {
                await logger.WriteLogAsync(CommonEnum.LogLevelEnum.Error, MethodBase.GetCurrentMethod(), exception: exception);
            }
        }
        #endregion
    }
}
