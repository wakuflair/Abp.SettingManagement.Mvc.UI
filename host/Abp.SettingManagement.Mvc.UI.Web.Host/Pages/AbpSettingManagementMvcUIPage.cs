using Microsoft.AspNetCore.Mvc.Localization;
using Microsoft.AspNetCore.Mvc.Razor.Internal;
using Abp.SettingManagement.Mvc.UI.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace Abp.SettingManagement.Mvc.UI.Pages
{
    public abstract class AbpSettingManagementMvcUIPage : AbpPage
    {
        [RazorInject]
        public IHtmlLocalizer<AbpSettingManagementMvcUIResource> L { get; set; }
    }
}
