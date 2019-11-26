using Volo.Abp.Http.Client.IdentityModel;
using Volo.Abp.Modularity;

namespace Abp.SettingManagement.Mvc.UI
{
    [DependsOn(
        typeof(AbpSettingManagementMvcUIHttpApiClientModule),
        typeof(AbpHttpClientIdentityModelModule)
        )]
    public class AbpSettingManagementMvcUIConsoleApiClientModule : AbpModule
    {
        
    }
}
