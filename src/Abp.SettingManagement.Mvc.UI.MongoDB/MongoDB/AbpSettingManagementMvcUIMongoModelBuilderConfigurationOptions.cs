using JetBrains.Annotations;
using Volo.Abp.MongoDB;

namespace Abp.SettingManagement.Mvc.UI.MongoDB
{
    public class AbpSettingManagementMvcUIMongoModelBuilderConfigurationOptions : AbpMongoModelBuilderConfigurationOptions
    {
        public AbpSettingManagementMvcUIMongoModelBuilderConfigurationOptions(
            [NotNull] string collectionPrefix = "")
            : base(collectionPrefix)
        {
        }
    }
}