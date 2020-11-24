using MyAbp.Themes.Basic.Components.Notification;
using System.Threading.Tasks;
using Volo.Abp.AspNetCore.Mvc.UI.Theme.Shared.Toolbars;

namespace MyAbp.Toolbars
{
    public class MyToolbarContributor : IToolbarContributor
    {
        public Task ConfigureToolbarAsync(IToolbarConfigurationContext context)
        {
            if (context.Toolbar.Name == StandardToolbars.Main)
            {
                context.Toolbar.Items
                    .Insert(0, new ToolbarItem(typeof(NotificationViewComponent)));
            }

            return Task.CompletedTask;
        }
    }
}
