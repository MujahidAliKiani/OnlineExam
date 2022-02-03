using OnlineExamSystem.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.Modularity;

namespace OnlineExamSystem.DbMigrator
{
    [DependsOn(
        typeof(AbpAutofacModule),
        typeof(OnlineExamSystemEntityFrameworkCoreDbMigrationsModule),
        typeof(OnlineExamSystemApplicationContractsModule)
        )]
    public class OnlineExamSystemDbMigratorModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpBackgroundJobOptions>(options => options.IsJobExecutionEnabled = false);
        }
    }
}
