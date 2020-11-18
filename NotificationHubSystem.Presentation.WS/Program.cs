using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NotificationHubSystem.Core;
using NotificationHubSystem.Infrastructure;
using NotificationHubSystem.Infrastructure.Context;
using NotificationHubSystem.SharedKernal;
using NotificationHubSystem.SharedKernal.Helper;
using NotificationHubSystem.SharedKernal.Settings;
using Microsoft.AspNetCore.Hosting; //<-- Here it is

namespace NotificationHubSystem.Presentation.WS
{
    public class Program
    {
        public static void Main(string[] args)
        {
            IHost host = CreateHostBuilder(args).Build();
            using IServiceScope scope = host.Services.CreateScope();
            AutoFacHelper.Container = scope.ServiceProvider;
            SharedKernal.Helper.SystemLogger.ILogger logger = scope.ServiceProvider.GetRequiredService<SharedKernal.Helper.SystemLogger.ILogger>();
            logger.WriteLog(SharedKernal.Enum.CommonEnum.LogLevelEnum.Information, System.Reflection.MethodBase.GetCurrentMethod(), message: $"Service Started ...");
            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
        .UseServiceProviderFactory(new AutofacServiceProviderFactory())
                        .UseWindowsService()
                        .ConfigureServices((hostContext, services) =>
                        {
                            IConfiguration configuration = hostContext.Configuration;
                            services.AddHostedService<Worker>();

                            SeriLogSettings seriLogSettings = new SeriLogSettings();
                            configuration.Bind("SeriLog", seriLogSettings);
                            services.AddSingleton(seriLogSettings);

                            PushNotificationSettings pushNotificationSettings = new PushNotificationSettings();
                            configuration.Bind("PushNotificationSettings", pushNotificationSettings);
                            services.AddSingleton(pushNotificationSettings);

                            WorkerSettings workerSettings = new WorkerSettings();
                            configuration.Bind("WorkerSettings", workerSettings);
                            services.AddSingleton(workerSettings);

                            //SMTPServerSettings smtpServerSettings = new SMTPServerSettings();
                            //configuration.Bind("SMTPServerSettings", smtpServerSettings);
                            //services.AddSingleton(smtpServerSettings);

                            //MailAppSettings mailAppSettings = new MailAppSettings();
                            //configuration.Bind("MailAppSettings", mailAppSettings);
                            //services.AddSingleton(mailAppSettings);

                            services.AddDbContext<AppDbContext>(cnf => cnf.UseSqlServer(configuration.GetConnectionString("DBConString")));
                        })
                        .ConfigureContainer<ContainerBuilder>((hostContext, builder) =>
                        {
                            IConfiguration configuration = hostContext.Configuration;
                            builder.RegisterModule(new SharedKernelModule(configuration));
                            builder.RegisterModule(new CoreModule(configuration));
                            builder.RegisterModule(new InfrastructureModule(configuration));
                        });


    }
}
