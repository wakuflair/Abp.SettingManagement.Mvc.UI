using Volo.Abp.AutoMapper;
using Volo.Abp.Modularity;
using Volo.Abp.Application;

namespace Abp.SettingManagement.Mvc.UI
{
    [DependsOn(
        typeof(AbpSettingManagementMvcUIDomainModule),
        typeof(AbpSettingManagementMvcUIApplicationContractsModule),
        typeof(AbpDddApplicationModule),
        typeof(AbpAutoMapperModule)
        )]
    public class AbpSettingManagementMvcUIApplicationModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpAutoMapperOptions>(options =>
            {
                options.AddMaps<AbpSettingManagementMvcUIApplicationModule>(validate: true);
            });
        }
    }
}
