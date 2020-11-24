using Volo.Abp.Reflection;

namespace MyAbp.Permissions
{
    public static class MyAbpPermissions
    {
        public const string GroupName = "MyAbp";

        //Add your own permission names. Example:
        //public const string MyPermission1 = GroupName + ".MyPermission1";

    }

    //public static class IdentityPermissions
    //{
    //    public const string GroupName = "AbpIdentity";

    //    public static class Roles
    //    {
    //        public const string Default = GroupName + ".Roles";
    //        public const string Create = Default + ".Create";
    //        public const string Update = Default + ".Update";
    //        public const string Delete = Default + ".Delete";
    //        public const string ManagePermissions = Default + ".ManagePermissions";
    //    }

    //    public static class Users
    //    {
    //        public const string Default = GroupName + ".Users";
    //        public const string Create = Default + ".Create";
    //        public const string Update = Default + ".Update";
    //        public const string Delete = Default + ".Delete";
    //        public const string ManagePermissions = Default + ".ManagePermissions";
    //    }

    //    public static class UserLookup
    //    {
    //        public const string Default = GroupName + ".UserLookup";
    //    }

    //    public static string[] GetAll()
    //    {
    //        return ReflectionHelper.GetPublicConstantsRecursively(typeof(IdentityPermissions));
    //    }
    //}
}