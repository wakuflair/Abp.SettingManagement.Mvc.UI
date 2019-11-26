using Abp.SettingManagement.Mvc.UI.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace Abp.SettingManagement.Mvc.UI.Authorization
{
    public class AbpSettingManagementMvcUIPermissionDefinitionProvider : PermissionDefinitionProvider
    {
        public override void Define(IPermissionDefinitionContext context)
        {
            var moduleGroup = context.AddGroup(AbpSettingManagementMvcUIPermissions.GroupName, L("Permission:AbpSettingManagementMvcUI"));
            moduleGroup.AddPermission(AbpSettingManagementMvcUIPermissions.Global, L("Permission:AbpSettingManagementMvcUI.Global"));
            moduleGroup.AddPermission(AbpSettingManagementMvcUIPermissions.Tenant, L("Permission:AbpSettingManagementMvcUI.Tenant"));
            moduleGroup.AddPermission(AbpSettingManagementMvcUIPermissions.User, L("Permission:AbpSettingManagementMvcUI.User"));
        }

        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<AbpSettingManagementMvcUIResource>(name);
        }
    }
}