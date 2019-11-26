using Volo.Abp.AspNetCore.TestBase;
using Volo.Abp.Modularity;

namespace Abp.SettingManagement.Mvc.UI.Web.Tests
{
    [DependsOn(typeof(AbpAspNetCoreTestBaseModule),
        typeof(AbpSettingManagementMvcUIWebModule),
        typeof(AbpSettingManagementMvcUIApplicationTestModule)
        )]
//    Depending on the Unified module, in order to load all the setting definitions
    [DependsOn(typeof(AbpSettingManagementMvcUIWebUnifiedModule))]
    public class AbpSettingManagementMvcUIWebTestModule  : AbpModule
    {
    }
}
