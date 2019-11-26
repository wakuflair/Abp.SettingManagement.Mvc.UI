using Abp.SettingManagement.Mvc.UI.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace Abp.SettingManagement.Mvc.UI
{
    /* Domain tests are configured to use the EF Core provider.
     * You can switch to MongoDB, however your domain tests should be
     * database independent anyway.
     */
    [DependsOn(
        typeof(AbpSettingManagementMvcUIEntityFrameworkCoreTestModule)
        )]
    public class AbpSettingManagementMvcUIDomainTestModule : AbpModule
    {
        
    }
}
