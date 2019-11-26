using Abp.SettingManagement.Mvc.UI.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace Abp.SettingManagement.Mvc.UI
{
    public abstract class AbpSettingManagementMvcUIController : AbpController
    {
        protected AbpSettingManagementMvcUIController()
        {
            LocalizationResource = typeof(AbpSettingManagementMvcUIResource);
        }
    }
}
