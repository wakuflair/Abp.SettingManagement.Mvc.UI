using Localization.Resources.AbpUi;
using Abp.SettingManagement.Mvc.UI.Localization;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;

namespace Abp.SettingManagement.Mvc.UI
{
    [DependsOn(
        typeof(AbpSettingManagementMvcUIApplicationContractsModule),
        typeof(AbpAspNetCoreMvcModule))]
    public class AbpSettingManagementMvcUIHttpApiModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpLocalizationOptions>(options =>
            {
                options.Resources
                    .Get<AbpSettingManagementMvcUIResource>()
                    .AddBaseTypes(typeof(AbpUiResource));
            });
        }
    }
}
