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
        #endregion
    }
}
