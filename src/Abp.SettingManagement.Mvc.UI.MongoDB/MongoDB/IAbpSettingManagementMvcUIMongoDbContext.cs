using Volo.Abp.Data;
using Volo.Abp.MongoDB;

namespace Abp.SettingManagement.Mvc.UI.MongoDB
{
    [ConnectionStringName(AbpSettingManagementMvcUIDbProperties.ConnectionStringName)]
    public interface IAbpSettingManagementMvcUIMongoDbContext : IAbpMongoDbContext
    {
        /* Define mongo collections here. Example:
         * IMongoCollection<Question> Questions { get; }
         */
    }
}
