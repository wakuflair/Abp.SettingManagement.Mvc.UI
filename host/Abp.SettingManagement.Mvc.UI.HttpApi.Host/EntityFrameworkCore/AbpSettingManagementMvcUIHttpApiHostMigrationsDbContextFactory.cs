using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Abp.SettingManagement.Mvc.UI.EntityFrameworkCore
{
    public class AbpSettingManagementMvcUIHttpApiHostMigrationsDbContextFactory : IDesignTimeDbContextFactory<AbpSettingManagementMvcUIHttpApiHostMigrationsDbContext>
    {
        public AbpSettingManagementMvcUIHttpApiHostMigrationsDbContext CreateDbContext(string[] args)
        {
            var configuration = BuildConfiguration();

            var builder = new DbContextOptionsBuilder<AbpSettingManagementMvcUIHttpApiHostMigrationsDbContext>()
                .UseSqlServer(configuration.GetConnectionString("Default"));

            return new AbpSettingManagementMvcUIHttpApiHostMigrationsDbContext(builder.Options);
        }

        private static IConfigurationRoot BuildConfiguration()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false);

            return builder.Build();
        }
    }
}
