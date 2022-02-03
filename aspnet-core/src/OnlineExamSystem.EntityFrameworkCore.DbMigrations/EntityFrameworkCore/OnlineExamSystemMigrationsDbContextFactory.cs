using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace OnlineExamSystem.EntityFrameworkCore
{
    /* This class is needed for EF Core console commands
     * (like Add-Migration and Update-Database commands) */
    public class OnlineExamSystemMigrationsDbContextFactory : IDesignTimeDbContextFactory<OnlineExamSystemMigrationsDbContext>
    {
        public OnlineExamSystemMigrationsDbContext CreateDbContext(string[] args)
        {
            OnlineExamSystemEfCoreEntityExtensionMappings.Configure();

            var configuration = BuildConfiguration();

            var builder = new DbContextOptionsBuilder<OnlineExamSystemMigrationsDbContext>()
                .UseSqlServer(configuration.GetConnectionString("Default"));

            return new OnlineExamSystemMigrationsDbContext(builder.Options);
        }

        private static IConfigurationRoot BuildConfiguration()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../OnlineExamSystem.DbMigrator/"))
                .AddJsonFile("appsettings.json", optional: false);

            return builder.Build();
        }
    }
}
