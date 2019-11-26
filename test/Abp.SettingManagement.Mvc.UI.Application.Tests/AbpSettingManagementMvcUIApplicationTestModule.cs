using Volo.Abp.Modularity;

namespace Abp.SettingManagement.Mvc.UI
{
    [DependsOn(
        typeof(AbpSettingManagementMvcUIApplicationModule),
        typeof(AbpSettingManagementMvcUIDomainTestModule)
        )]
    public class AbpSettingManagementMvcUIApplicationTestModule : AbpModule
    {

    }
}
