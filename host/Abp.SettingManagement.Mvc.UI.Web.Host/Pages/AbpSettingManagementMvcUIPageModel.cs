using Abp.SettingManagement.Mvc.UI.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace Abp.SettingManagement.Mvc.UI.Pages
{
    public abstract class AbpSettingManagementMvcUIPageModel : AbpPageModel
    {
        protected AbpSettingManagementMvcUIPageModel()
        {
            LocalizationResourceType = typeof(AbpSettingManagementMvcUIResource);
        }
    }
}