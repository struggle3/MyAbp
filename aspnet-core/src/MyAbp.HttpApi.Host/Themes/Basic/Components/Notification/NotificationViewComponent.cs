using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Volo.Abp.AspNetCore.Mvc;

namespace MyAbp.Themes.Basic.Components.Notification
{
    public class NotificationViewComponent : AbpViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View("/Themes/Basic/Components/Notification/Default.cshtml");
        }
    }
}
