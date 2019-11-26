using Microsoft.AspNetCore.Mvc.Localization;
using Microsoft.AspNetCore.Mvc.Razor.Internal;
using Abp.SettingManagement.Mvc.UI.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace Abp.SettingManagement.Mvc.UI.Web.Pages
{
    /* Inherit your UI Pages from this class. To do that, add this line to your Pages (.cshtml files under the Page folder):
     * @inherits Abp.SettingManagement.Mvc.UI.Web.PagesAbpSettingManagementMvcUIPage
     */
    public abstract class AbpSettingManagementMvcUIPage : AbpPage
    {
        [RazorInject]
        public IHtmlLocalizer<AbpSettingManagementMvcUIResource> L { get; set; }
    }
}
