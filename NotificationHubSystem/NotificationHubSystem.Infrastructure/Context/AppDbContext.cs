using Microsoft.EntityFrameworkCore;

namespace NotificationHubSystem.Infrastructure.Context
{
    public partial class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public static void Configure(DbContextOptionsBuilder<AppDbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            SingularizeTableNames(modelBuilder);

            base.OnModelCreating(modelBuilder);

            modelBuilder.BuildEnums();
            modelBuilder.BuildMainData();
        }

    }
}
