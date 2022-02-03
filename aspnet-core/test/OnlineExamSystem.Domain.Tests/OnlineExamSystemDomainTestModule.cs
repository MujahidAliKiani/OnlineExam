using OnlineExamSystem.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace OnlineExamSystem
{
    [DependsOn(
        typeof(OnlineExamSystemEntityFrameworkCoreTestModule)
        )]
    public class OnlineExamSystemDomainTestModule : AbpModule
    {

    }
}