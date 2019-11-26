using Volo.Abp.Data;
using Volo.Abp.MongoDB;

namespace Abp.SettingManagement.Mvc.UI.MongoDB
{
    [ConnectionStringName(AbpSettingManagementMvcUIDbProperties.ConnectionStringName)]
    public class AbpSettingManagementMvcUIMongoDbContext : AbpMongoDbContext, IAbpSettingManagementMvcUIMongoDbContext
    {
        /* Add mongo collections here. Example:
         * public IMongoCollection<Question> Questions => Collection<Question>();
         */

        protected override void CreateModel(IMongoModelBuilder modelBuilder)
        {
            base.CreateModel(modelBuilder);

            modelBuilder.ConfigureAbpSettingManagementMvcUI();
        }
    }
}