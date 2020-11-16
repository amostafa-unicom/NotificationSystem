using Autofac;
using Microsoft.Extensions.Configuration;
using NotificationHubSystem.SharedKernal.AppConfiguration.Base;
using NotificationHubSystem.SharedKernal.Helper.SystemLogger;
using NotificationHubSystem.SharedKernal.ResourcesReader.Message;

namespace NotificationHubSystem.SharedKernal
{
    public class SharedKernelModule : Module
    {
        #region Properties
        public IConfiguration Configuration { get; }
        #endregion

        #region Constructor
        public SharedKernelModule(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        #endregion

        #region Public - Methods
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<BasePresenter>().SingleInstance();
            builder.RegisterType<Logger>().As<ILogger>().SingleInstance();
            builder.RegisterType<MessageResourceReader>().As<IMessageResourceReader>().PropertiesAutowired().InstancePerLifetimeScope();
        }
        #endregion
    }
}
