using MyAbp.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace MyAbp.Permissions
{
    public class MyAbpPermissionDefinitionProvider : PermissionDefinitionProvider
    {
        public override void Define(IPermissionDefinitionContext context)
        {
            var myGroup = context.AddGroup(MyAbpPermissions.GroupName);

            //Define your own permissions here. Example:
            //myGroup.AddPermission(MyAbpPermissions.MyPermission1, L("Permission:MyPermission1"));
        }

        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<MyAbpResource>(name);
        }
    }
}
