using System;
using System.Collections.Generic;
using System.Text;
using MyAbp.Localization;
using Volo.Abp.Application.Services;

namespace MyAbp
{
    /* Inherit your application services from this class.
     */
    public abstract class MyAbpAppService : ApplicationService
    {
        protected MyAbpAppService()
        {
            LocalizationResource = typeof(MyAbpResource);
        }
    }
}
