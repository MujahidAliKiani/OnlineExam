using OnlineExamSystem.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace OnlineExamSystem.Controllers
{
    /* Inherit your controllers from this class.
     */
    public abstract class OnlineExamSystemController : AbpController
    {
        protected OnlineExamSystemController()
        {
            LocalizationResource = typeof(OnlineExamSystemResource);
        }
    }
}