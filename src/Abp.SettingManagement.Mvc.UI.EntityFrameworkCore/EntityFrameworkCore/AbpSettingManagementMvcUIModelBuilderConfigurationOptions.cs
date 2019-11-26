using JetBrains.Annotations;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace Abp.SettingManagement.Mvc.UI.EntityFrameworkCore
{
    public class AbpSettingManagementMvcUIModelBuilderConfigurationOptions : AbpModelBuilderConfigurationOptions
    {
        public AbpSettingManagementMvcUIModelBuilderConfigurationOptions(
            [NotNull] string tablePrefix = "",
            [CanBeNull] string schema = null)
            : base(
                tablePrefix,
                schema)
        {

        }
    }
}