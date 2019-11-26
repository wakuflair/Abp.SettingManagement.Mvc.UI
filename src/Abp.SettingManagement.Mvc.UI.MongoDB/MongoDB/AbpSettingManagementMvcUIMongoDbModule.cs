using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Modularity;
using Volo.Abp.MongoDB;

namespace Abp.SettingManagement.Mvc.UI.MongoDB
{
    [DependsOn(
        typeof(AbpSettingManagementMvcUIDomainModule),
        typeof(AbpMongoDbModule)
        )]
    public class AbpSettingManagementMvcUIMongoDbModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddMongoDbContext<AbpSettingManagementMvcUIMongoDbContext>(options =>
            {
                /* Add custom repositories here. Example:
                 * options.AddRepository<Question, MongoQuestionRepository>();
                 */
            });
        }
    }
}
