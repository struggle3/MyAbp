using System.Threading.Tasks;
using MyAbp.Localization;
using Volo.Abp.Identity;
using Volo.Abp.Identity.Blazor;
using Volo.Abp.Identity.Localization;
using Volo.Abp.TenantManagement;
using Volo.Abp.TenantManagement.Blazor.Navigation;
using Volo.Abp.TenantManagement.Localization;
using Volo.Abp.UI.Navigation;
using Volo.Abp.Users;

namespace MyAbp.Blazor
{
    public class MyAbpMenuContributor : IMenuContributor
    {
        public async Task ConfigureMenuAsync(MenuConfigurationContext context)
        {

            if (context.Menu.Name != StandardMenus.Main)
            {
                return;
            }

            var appLocalizer = context.GetLocalizer<MyAbpResource>();
            

            context.Menu.Items.Insert(
                0,
                new ApplicationMenuItem(
                    "MyAbp.Home",
                    appLocalizer["Menu:Home"],
                    "/",
                    icon: "home"
                )
            );
            
            var administrationMenu = context.Menu.GetAdministration();
            administrationMenu.Items.RemoveAll(m => true);
            administrationMenu.Icon = "global";
            administrationMenu.Url = "/admin";

            var hasTenantPermission = await context.IsGrantedAsync(TenantManagementPermissions.Tenants.Default);
            if (hasTenantPermission)
            {
                var tenantLocalizer = context.GetLocalizer<AbpTenantManagementResource>();
                var tenantManagementMenuItem = new ApplicationMenuItem(TenantManagementMenuNames.GroupName, tenantLocalizer["Menu:TenantManagement"], url: "/tenant", icon: "solution");
                administrationMenu.AddItem(tenantManagementMenuItem);
                tenantManagementMenuItem.AddItem(new ApplicationMenuItem(TenantManagementMenuNames.Tenants, tenantLocalizer["Tenants"], url: "/tenant/tenants"));
            }

            var hasRolePermission = await context.IsGrantedAsync(IdentityPermissions.Roles.Default);
            var hasUserPermission = await context.IsGrantedAsync(IdentityPermissions.Users.Default);

            if (hasRolePermission || hasUserPermission)
            {
                var identityLocalizer = context.GetLocalizer<IdentityResource>();

                var identityMenuItem = new ApplicationMenuItem(IdentityMenuNames.GroupName, identityLocalizer["Menu:IdentityManagement"], url:"/identitys", icon: "team");
                administrationMenu.AddItem(identityMenuItem);

                if (hasRolePermission)
                {
                    identityMenuItem.AddItem(new ApplicationMenuItem(IdentityMenuNames.Roles, identityLocalizer["Roles"], url: "/identitys/roles"));
                }

                if (hasUserPermission)
                {
                    identityMenuItem.AddItem(new ApplicationMenuItem(IdentityMenuNames.Users, identityLocalizer["Users"], url: "/identitys/users"));
                }
            }
        }
    }
}
