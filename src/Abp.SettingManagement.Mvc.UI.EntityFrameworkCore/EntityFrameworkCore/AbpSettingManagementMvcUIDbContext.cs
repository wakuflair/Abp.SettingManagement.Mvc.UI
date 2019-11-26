using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace Abp.SettingManagement.Mvc.UI.EntityFrameworkCore
{
    [ConnectionStringName(AbpSettingManagementMvcUIDbProperties.ConnectionStringName)]
    public class AbpSettingManagementMvcUIDbContext : AbpDbContext<AbpSettingManagementMvcUIDbContext>, IAbpSettingManagementMvcUIDbContext
    {
        /* Add DbSet for each Aggregate Root here. Example:
         * public DbSet<Question> Questions { get; set; }
         */

        public AbpSettingManagementMvcUIDbContext(DbContextOptions<AbpSettingManagementMvcUIDbContext> options) 
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ConfigureAbpSettingManagementMvcUI();
        }
    }
}