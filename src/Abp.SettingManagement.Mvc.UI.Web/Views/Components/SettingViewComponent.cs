using System.Collections.Generic;
using System.Linq;
using Abp.SettingManagement.Mvc.UI.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Localization;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc.UI.Widgets;
using Volo.Abp.Localization;
using Volo.Abp.Settings;

namespace Abp.SettingManagement.Mvc.UI.Web.Views.Components
{
    [Widget(StyleFiles = new []{"/Views/Components/Default.css"})]
    public class SettingViewComponent : AbpViewComponent
    {
        private readonly IHtmlLocalizer<AbpSettingManagementMvcUIResource> _localizer;

        public SettingViewComponent(IHtmlLocalizer<AbpSettingManagementMvcUIResource> localizer)
        {
            _localizer = localizer;
        }

        public IViewComponentResult Invoke(IEnumerable<SettingDefinition> parameter)
        {
            var settingInfos = parameter.Select((sd, index) => new SettingHtmlInfo(sd, _localizer, index));
            return View("/Views/Components/Default.cshtml", settingInfos);
        }
    }

    public class SettingHtmlInfo
    {
        public string Name { get; }
        public LocalizedHtmlString DisplayName { get; }
        public LocalizedHtmlString Description { get; }
        public string Group1 { get; set; }
        public string Group2 { get; set; }
        public string Type { get; }
        public string Id { get; }
        public SettingDefinition SettingDefinition { get; }

        public SettingHtmlInfo(SettingDefinition settingDefinition, IHtmlLocalizer<AbpSettingManagementMvcUIResource> localizer, int index)
        {
            Name = settingDefinition.Name;
            DisplayName = localizer["DisplayName:" + settingDefinition.Name];
            Description = localizer["Description:" + settingDefinition.Name];
            Group1 = (string) settingDefinition.Properties[AbpSettingManagementMvcUIConst.Group1];
            Group2 = (string) settingDefinition.Properties[AbpSettingManagementMvcUIConst.Group2];
            Type = (string)settingDefinition.Properties[AbpSettingManagementMvcUIConst.Type];
            Id = $"Setting{index}";
            SettingDefinition = settingDefinition;
        }
    }
}