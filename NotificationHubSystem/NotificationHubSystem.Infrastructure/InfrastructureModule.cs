using Autofac;
using AutoMapper;
using NotificationHubSystem.Core.Interfaces.Repository.Common;
using NotificationHubSystem.Infrastructure.Helper;
using System;
using System.Linq;
using NotificationHubSystem.Core.Interfaces.Helper;
using Microsoft.Extensions.Configuration;
using NotificationHubSystem.Infrastructure.Context;

namespace NotificationHubSystem.Infrastructure
{
    public class InfrastructureModule : Module
    {
        #region Properties
        public IConfiguration Configuration { get; }
        #endregion

        #region Constructor
        public InfrastructureModule(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        #endregion

        #region Public - Methods
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<AppDbContext>().WithParameter("options", AppDbContextFactory.Get(this.Configuration)).InstancePerLifetimeScope();

            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().PropertiesAutowired().InstancePerLifetimeScope();
            builder.RegisterType<HttpRequest>().As<IHttpRequest>().InstancePerLifetimeScope();
            ResolveMapper(builder);
            ResolveRepositories(builder);
        }
        #endregion

        #region Private - Methods
        private void ResolveMapper(ContainerBuilder builder)
        {
            Type[] mappers = System.Reflection.Assembly.Load(typeof(Mapping.CityMapping).Assembly.GetName()).GetTypes().Where(x => x.IsSubclassOf(typeof(Profile))).ToArray();
            MapperConfiguration mappingConfig = new MapperConfiguration(mc => mappers.ToList().ForEach(item => mc.AddProfile(item)));
            IMapper mapper = mappingConfig.CreateMapper();
            builder.Register(ctx => mapper).PropertiesAutowired().SingleInstance();
        }

        private void ResolveRepositories(ContainerBuilder builder)
        {
            var repositoryClass = typeof(Repository.Custom.NotificationBaseRepository);
            var repositoryInterface = typeof(Core.Interfaces.Repository.Custom.INotificationBaseRepository);
            Type[] repository = System.Reflection.Assembly.Load(repositoryClass.Assembly.GetName()).GetTypes().Where(x => x.Name.Trim().ToLower().EndsWith("repository")).ToArray();
            Type[] iRepository = System.Reflection.Assembly.Load(repositoryInterface.Assembly.GetName()).GetTypes().Where(x => x.Name.Trim().ToLower().EndsWith("repository") && x.IsInterface).ToArray();
            Resolve(builder, repository, iRepository);
        }

        private void Resolve(ContainerBuilder builder, Type[] repository, Type[] irepository)
        {
            foreach (Type repositoryInterface in irepository)
            {
                Type classType = repository.FirstOrDefault(x => repositoryInterface.IsAssignableFrom(x));
                if (classType != null)
                {
                    builder.RegisterType(classType).As(repositoryInterface).PropertiesAutowired().InstancePerLifetimeScope();
                }
            }
        }
        #endregion
    }
}
