using Volo.Abp.Modularity;

namespace Abp.SettingManagement.Mvc.UI
{
    [DependsOn(
        typeof(AbpSettingManagementMvcUIDomainSharedModule)
        )]
    public class AbpSettingManagementMvcUIDomainModule : AbpModule
    {

    }
}
