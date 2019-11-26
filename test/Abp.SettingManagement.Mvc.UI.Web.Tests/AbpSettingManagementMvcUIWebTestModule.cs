using Volo.Abp.AspNetCore.TestBase;
using Volo.Abp.Data;
using Volo.Abp.Modularity;

namespace Abp.SettingManagement.Mvc.UI.Web.Tests
{
    [DependsOn(typeof(AbpAspNetCoreTestBaseModule),
        typeof(AbpSettingManagementMvcUIWebModule),
        typeof(AbpSettingManagementMvcUIApplicationTestModule)
        )]
    //    Depending on the Unified module, in order to load all the setting definitions
    [DependsOn(typeof(AbpSettingManagementMvcUIWebUnifiedModule))]
    public class AbpSettingManagementMvcUIWebTestModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            // In order to depend on the Unified module, we must configure the connect string
            Configure<AbpDbConnectionOptions>(conn =>
            {
                conn.ConnectionStrings.Default =
                    "Server=(localdb)\\mssqllocaldb;Database=AbpSettingManagementMvcUI_Unified;Trusted_Connection=True";
            });
        }
    }
}
