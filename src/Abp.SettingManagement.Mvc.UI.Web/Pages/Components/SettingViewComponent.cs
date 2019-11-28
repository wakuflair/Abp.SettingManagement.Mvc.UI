using System.Collections.Generic;
using System.Linq;
using Abp.SettingManagement.Mvc.UI.Extensions;
using Abp.SettingManagement.Mvc.UI.Localization;
using Abp.SettingManagement.Mvc.UI.SettingManagementUI.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Localization;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc.UI.Widgets;
using Volo.Abp.Localization;
using Volo.Abp.Settings;
using Volo.Abp.Threading;

namespace Abp.SettingManagement.Mvc.UI.Web.Pages.Components
{
    [Widget(StyleFiles = new[] { "/Pages/Components/Default.css" })]
    public class SettingViewComponent : AbpViewComponent
    {
        private readonly IHtmlLocalizer<AbpSettingManagementMvcUIResource> _localizer;
        private readonly ISettingProvider _settingProvider;

        public SettingViewComponent(IHtmlLocalizer<AbpSettingManagementMvcUIResource> localizer, ISettingProvider settingProvider)
        {
            _localizer = localizer;
            _settingProvider = settingProvider;
        }

        public IViewComponentResult Invoke(SettingGroup parameter)
        {
            var settingInfos = parameter.SettingDefinitions.Select((sd, index) => new SettingHtmlInfo(
                sd,
                _localizer["DisplayName:" + sd.Name],
                _localizer["Description:" + sd.Name],
                AsyncHelper.RunSync(() => _settingProvider.GetOrNullAsync(sd.Name))
                ));
            return View("~/Pages/Components/Default.cshtml", settingInfos);
        }
    }

    public class SettingHtmlInfo
    {
        public string Name { get; }
        public LocalizedHtmlString DisplayName { get; }
        public LocalizedHtmlString Description { get; }
        public string Value { get; }
        public string Group1 { get; }
        public string Group2 { get; }
        public string FormName { get; }
        public string Type { get; }
        public SettingDefinition SettingDefinition { get; }

        public SettingHtmlInfo(SettingDefinition settingDefinition,
            LocalizedHtmlString displayName, LocalizedHtmlString description,
            string value)
        {
            Name = settingDefinition.Name;
            DisplayName = displayName;
            Description = description;
            Value = value;
            Group1 = (string)settingDefinition.Properties[AbpSettingManagementMvcUIConst.Group1];
            Group2 = (string)settingDefinition.Properties[AbpSettingManagementMvcUIConst.Group2];
            FormName = AbpSettingManagementMvcUIConst.FormNamePrefix + Name.DotToUnderscore();
            Type = (string)settingDefinition.Properties[AbpSettingManagementMvcUIConst.Type];
            SettingDefinition = settingDefinition;
        }
    }
}