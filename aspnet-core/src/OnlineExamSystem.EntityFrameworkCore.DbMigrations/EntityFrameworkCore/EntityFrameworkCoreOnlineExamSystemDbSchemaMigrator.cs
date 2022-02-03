using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using OnlineExamSystem.Data;
using Volo.Abp.DependencyInjection;

namespace OnlineExamSystem.EntityFrameworkCore
{
    public class EntityFrameworkCoreOnlineExamSystemDbSchemaMigrator
        : IOnlineExamSystemDbSchemaMigrator, ITransientDependency
    {
        private readonly IServiceProvider _serviceProvider;

        public EntityFrameworkCoreOnlineExamSystemDbSchemaMigrator(
            IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task MigrateAsync()
        {
            /* We intentionally resolving the OnlineExamSystemMigrationsDbContext
             * from IServiceProvider (instead of directly injecting it)
             * to properly get the connection string of the current tenant in the
             * current scope.
             */

            await _serviceProvider
                .GetRequiredService<OnlineExamSystemMigrationsDbContext>()
                .Database
                .MigrateAsync();
        }
    }
}