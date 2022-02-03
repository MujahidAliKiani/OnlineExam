using System;
using System.Collections.Generic;
using System.Text;
using OnlineExamSystem.Localization;
using Volo.Abp.Application.Services;

namespace OnlineExamSystem
{
    /* Inherit your application services from this class.
     */
    public abstract class OnlineExamSystemAppService : ApplicationService
    {
        protected OnlineExamSystemAppService()
        {
            LocalizationResource = typeof(OnlineExamSystemResource);
        }
    }
}
