using System.Threading.Tasks;
using MyAbp.Localization;
using Volo.Abp.UI.Navigation;

namespace MyAbp.Blazor
{
    public class MyAbpMenuContributor : IMenuContributor
    {
        public Task ConfigureMenuAsync(MenuConfigurationContext context)
        {
            if(context.Menu.DisplayName != StandardMenus.Main)
            {
                return Task.CompletedTask;
            }

            var l = context.GetLocalizer<MyAbpResource>();

            context.Menu.Items.Insert(
                0,
                new ApplicationMenuItem(
                    "MyAbp.Home",
                    l["Menu:Home"],
                    "/",
                    icon: "fas fa-home"
                )
            );

            return Task.CompletedTask;
        }
    }
}
