using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace Abp.SettingManagement.Mvc.UI.EntityFrameworkCore
{
    [ConnectionStringName(AbpSettingManagementMvcUIDbProperties.ConnectionStringName)]
    public interface IAbpSettingManagementMvcUIDbContext : IEfCoreDbContext
    {
        /* Add DbSet for each Aggregate Root here. Example:
         * DbSet<Question> Questions { get; }
         */
    }
}