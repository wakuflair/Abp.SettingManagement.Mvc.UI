using Volo.Abp.Application;
using Volo.Abp.Modularity;
using Volo.Abp.VirtualFileSystem;
using Volo.Abp.Authorization;

namespace Abp.SettingManagement.Mvc.UI
{
    [DependsOn(
        typeof(AbpSettingManagementMvcUIDomainSharedModule),
        typeof(AbpDddApplicationContractsModule),
        typeof(AbpAuthorizationModule)
        )]
    public class AbpSettingManagementMvcUIApplicationContractsModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpVirtualFileSystemOptions>(options =>
            {
                options.FileSets.AddEmbedded<AbpSettingManagementMvcUIApplicationContractsModule>("Abp.SettingManagement.Mvc.UI");
            });
        }
    }
}
