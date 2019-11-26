using Volo.Abp.AspNetCore.Mvc.UI.Theme.Shared.Components;
using Volo.Abp.DependencyInjection;

namespace Abp.SettingManagement.Mvc.UI
{
    [Dependency(ReplaceServices = true)]
    public class AbpSettingManagementMvcUIBrandingProvider : DefaultBrandingProvider
    {
        public override string AppName => "AbpSettingManagementMvcUI";
    }
}
