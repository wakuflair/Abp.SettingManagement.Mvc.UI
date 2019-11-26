using System;
using Volo.Abp;
using Volo.Abp.MongoDB;

namespace Abp.SettingManagement.Mvc.UI.MongoDB
{
    public static class AbpSettingManagementMvcUIMongoDbContextExtensions
    {
        public static void ConfigureAbpSettingManagementMvcUI(
            this IMongoModelBuilder builder,
            Action<AbpMongoModelBuilderConfigurationOptions> optionsAction = null)
        {
            Check.NotNull(builder, nameof(builder));

            var options = new AbpSettingManagementMvcUIMongoModelBuilderConfigurationOptions(
                AbpSettingManagementMvcUIDbProperties.DbTablePrefix
            );

            optionsAction?.Invoke(options);
        }
    }
}