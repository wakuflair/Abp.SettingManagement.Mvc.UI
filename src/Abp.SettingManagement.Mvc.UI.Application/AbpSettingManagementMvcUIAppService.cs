using Abp.SettingManagement.Mvc.UI.Localization;
using Volo.Abp.Application.Services;

namespace Abp.SettingManagement.Mvc.UI
{
    public abstract class AbpSettingManagementMvcUIAppService : ApplicationService
    {
        protected AbpSettingManagementMvcUIAppService()
        {
            LocalizationResource = typeof(AbpSettingManagementMvcUIResource);
        }
    }
}
