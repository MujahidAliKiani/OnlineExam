using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace OnlineExamSystem
{
    [Dependency(ReplaceServices = true)]
    public class OnlineExamSystemBrandingProvider : DefaultBrandingProvider
    {
        public override string AppName => "OnlineExamSystem";
    }
}
