using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Modularity;

namespace OnlineExamSystem.EntityFrameworkCore
{
    [DependsOn(
        typeof(OnlineExamSystemEntityFrameworkCoreModule)
        )]
    public class OnlineExamSystemEntityFrameworkCoreDbMigrationsModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAbpDbContext<OnlineExamSystemMigrationsDbContext>();
        }
    }
}
