using Volo.Abp.Reflection;

namespace Abp.SettingManagement.Mvc.UI.Authorization
{
    public class AbpSettingManagementMvcUIPermissions
    {
        public const string GroupName = "AbpSettingManagementMvcUI";
        public const string Global = GroupName + ".Global";
        public const string Tenant = GroupName + ".Tenant";
        public const string User = GroupName + ".User";

        public static string[] GetAll()
        {
            return ReflectionHelper.GetPublicConstantsRecursively(typeof(AbpSettingManagementMvcUIPermissions));
        }
    }
}