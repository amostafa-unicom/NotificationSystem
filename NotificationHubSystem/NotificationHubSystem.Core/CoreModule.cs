using Autofac;
using Microsoft.Extensions.Configuration;
using System;
using System.Linq;

namespace NotificationHubSystem.Core
{
    public class CoreModule : Module
    {
        #region Properties
        public IConfiguration Configuration { get; }
        #endregion

        #region Constructor
        public CoreModule(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        #endregion

        #region Public - Methods
        protected override void Load(ContainerBuilder builder)
        {
            ResolveUseCases(builder);
        }
        #endregion

        #region Private - Methods
        private void ResolveUseCases(ContainerBuilder builder)
        {
            Type[] useCase = System.Reflection.Assembly.Load(typeof(UseCases.MailAddUseCase.MailAddUseCase).Assembly.GetName()).GetTypes().Where(x => x.IsSubclassOf(typeof(Base.BaseUseCase))).ToArray();
            Type[] iUseCase = System.Reflection.Assembly.Load(typeof(UseCases.MailAddUseCase.IMailAddUseCase).Assembly.GetName()).GetTypes().Where(a => a.IsInterface).ToArray();
            Resolve(builder, useCase, iUseCase);
        }
        private void Resolve(ContainerBuilder builder, Type[] useCase, Type[] iUseCase)
        {
            foreach (Type useCaseInterface in iUseCase)
            {
                Type classType = useCase.FirstOrDefault(x => useCaseInterface.IsAssignableFrom(x));
                if (classType != null)
                {
                    builder.RegisterType(classType).As(useCaseInterface).PropertiesAutowired().InstancePerLifetimeScope();
                }
            }
        }
        #endregion
    }
}
