using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc.UI.Widgets;
using Volo.Abp.Settings;

namespace Abp.SettingManagement.Mvc.UI.Web.Views.Components
{
    [Widget(StyleFiles = new []{"/Views/Components/Default.css"})]
    public class SettingViewComponent : AbpViewComponent
    {
        public IViewComponentResult Invoke(IEnumerable<SettingDefinition> parameter)
        {
            return View("/Views/Components/Default.cshtml", parameter);
        }
    }
}