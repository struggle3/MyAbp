using MyAbp.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace MyAbp.Controllers
{
    /* Inherit your controllers from this class.
     */
    public abstract class MyAbpController : AbpController
    {
        protected MyAbpController()
        {
            LocalizationResource = typeof(MyAbpResource);
        }
    }
}