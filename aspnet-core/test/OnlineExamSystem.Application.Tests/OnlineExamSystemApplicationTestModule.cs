using Volo.Abp.Modularity;

namespace OnlineExamSystem
{
    [DependsOn(
        typeof(OnlineExamSystemApplicationModule),
        typeof(OnlineExamSystemDomainTestModule)
        )]
    public class OnlineExamSystemApplicationTestModule : AbpModule
    {

    }
}