using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace NotificationHubSystem.Infrastructure.Context
{
    public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public static DbContextOptions<AppDbContext> Get(IConfiguration configuration)
        {
            DbContextOptionsBuilder<AppDbContext> builder = new DbContextOptionsBuilder<AppDbContext>();
            AppDbContext.Configure(builder, configuration.GetConnectionString("DBConString"));
            return builder.Options;
        }
        public AppDbContext CreateDbContext(string[] args)
        {
            IConfiguration configuration = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
                                           .AddJsonFile(Path.Combine(Directory.GetCurrentDirectory(), @"bin\Debug\netcoreapp3.1", "appsettings.json"), optional: false, reloadOnChange: true)
                                           .Build();
            return new AppDbContext(Get(configuration));
        }
    }
}