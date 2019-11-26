namespace Abp.SettingManagement.Mvc.UI
{
    public static class AbpSettingManagementMvcUIDbProperties
    {
        public static string DbTablePrefix { get; set; } = "AbpSettingManagementMvcUI";

        public static string DbSchema { get; set; } = null;

        public const string ConnectionStringName = "AbpSettingManagementMvcUI";
    }
}
