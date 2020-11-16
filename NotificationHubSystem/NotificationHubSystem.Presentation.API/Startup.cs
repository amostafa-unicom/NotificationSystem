
using Autofac;
using NotificationHubSystem.Core;
using NotificationHubSystem.Infrastructure;
using NotificationHubSystem.Infrastructure.Context;
using NotificationHubSystem.SharedKernal;
using NotificationHubSystem.SharedKernal.AppConfiguration;
using NotificationHubSystem.SharedKernal.Settings;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.Reflection;
using NotificationHubSystem.SharedKernal.Enum;

namespace NotificationHubSystem.Presentation.API
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public void ConfigureServices(IServiceCollection services)
        {
            #region App Register
            services.AddAPIConfig(Configuration, useCORS: true, useSwagger: true, useFluentValidation: true);
            #endregion
            services.AddControllersWithViews().AddControllersAsServices().AddNewtonsoftJson();
        }
        public void ConfigureContainer(ContainerBuilder builder)
        {
            builder.RegisterModule(new SharedKernelModule(Configuration));
            builder.RegisterModule(new CoreModule(Configuration));
            builder.RegisterModule(new InfrastructureModule(Configuration));

            #region Register Controller For Property DI
            System.Type controllerBaseType = typeof(SharedKernal.AppConfiguration.Base.BaseController);
            builder.RegisterAssemblyTypes(typeof(Program).Assembly).Where(t => controllerBaseType.IsAssignableFrom(t) && t != controllerBaseType).PropertiesAutowired();
            #endregion
        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory, SwaggerSettings swaggerSettings)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            #region App Register
            app.UseAPIConfig(loggerFactory, swaggerSettings, useCORS: true, useSwagger: true);
            #endregion

            #region End Point & Routes
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            #endregion

            #region EF Create & Migrate
            SharedKernal.Helper.SystemLogger.ILogger logger = app.ApplicationServices.GetRequiredService<SharedKernal.Helper.SystemLogger.ILogger>();
            AppDbContext context = app.ApplicationServices.GetRequiredService<AppDbContext>();
            logger.WriteLog(CommonEnum.LogLevelEnum.Information, MethodBase.GetCurrentMethod(), message: "Ensure database created.");
            try
            {
                logger.WriteLog(CommonEnum.LogLevelEnum.Information, MethodBase.GetCurrentMethod(), message: "Database already up to date.");
                context.Database.Migrate();
                logger.WriteLog(CommonEnum.LogLevelEnum.Information, MethodBase.GetCurrentMethod(), message: "Migration has been applied.");
            }
            catch (System.Exception exception)
            {
                logger.WriteLog(CommonEnum.LogLevelEnum.Error, MethodBase.GetCurrentMethod(), exception: exception);
            }
            #endregion
        }
    }
}
