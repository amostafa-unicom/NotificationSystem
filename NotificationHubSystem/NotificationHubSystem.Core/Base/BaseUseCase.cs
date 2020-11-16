using AutoMapper;
using NotificationHubSystem.Core.Interfaces.Repository.Common;
using NotificationHubSystem.SharedKernal.ResourcesReader.Message;
using NotificationHubSystem.SharedKernal.Settings;

namespace NotificationHubSystem.Core.Base
{
    internal abstract class BaseUseCase
    {
        #region Properties
        public AppSettings AppSettings { get; set; }
        public WorkerSettings WorkerSettings { get; set; }
        public IMessageResourceReader MessageResource { get; set; }
        public IUnitOfWork UnitOfWork { get; set; }
        public IMapper Mapper { get; set; }
        #endregion
    }
}
