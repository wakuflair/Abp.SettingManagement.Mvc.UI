using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Modularity;
using Volo.Abp.VirtualFileSystem;

namespace Abp.SettingManagement.Mvc.UI
{
    [DependsOn(
        typeof(AbpSettingManagementMvcUIApplicationModule),
        typeof(AbpSettingManagementMvcUIDomainTestModule)
        )]
    public class AbpSettingManagementMvcUIApplicationTestModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpVirtualFileSystemOptions>(options =>
            {
                options.FileSets.AddEmbedded<AbpSettingManagementMvcUIApplicationTestModule>("Abp.SettingManagement.Mvc.UI");
            });
        }
    }
}
