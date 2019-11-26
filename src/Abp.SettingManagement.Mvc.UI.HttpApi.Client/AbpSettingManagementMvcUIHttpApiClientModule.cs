using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Http.Client;
using Volo.Abp.Modularity;

namespace Abp.SettingManagement.Mvc.UI
{
    [DependsOn(
        typeof(AbpSettingManagementMvcUIApplicationContractsModule),
        typeof(AbpHttpClientModule))]
    public class AbpSettingManagementMvcUIHttpApiClientModule : AbpModule
    {
        public const string RemoteServiceName = "AbpSettingManagementMvcUI";

        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddHttpClientProxies(
                typeof(AbpSettingManagementMvcUIApplicationContractsModule).Assembly,
                RemoteServiceName
            );
        }
    }
}
