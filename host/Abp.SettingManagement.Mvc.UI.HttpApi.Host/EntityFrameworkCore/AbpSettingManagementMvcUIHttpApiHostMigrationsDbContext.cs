using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Abp.SettingManagement.Mvc.UI.EntityFrameworkCore
{
    public class AbpSettingManagementMvcUIHttpApiHostMigrationsDbContext : AbpDbContext<AbpSettingManagementMvcUIHttpApiHostMigrationsDbContext>
    {
        public AbpSettingManagementMvcUIHttpApiHostMigrationsDbContext(DbContextOptions<AbpSettingManagementMvcUIHttpApiHostMigrationsDbContext> options)
            : base(options)
        {
        
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ConfigureAbpSettingManagementMvcUI();
        }
    }
}
