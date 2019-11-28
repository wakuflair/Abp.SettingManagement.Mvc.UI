using System.Collections.Generic;
using Volo.Abp.Settings;

namespace Abp.SettingManagement.Mvc.UI.SettingManagementUI.Dto
{
    public class SettingGroup
    {
        public string GroupName { get; set; }
        public string GroupDisplayName { get; set; }
        public IEnumerable<SettingDefinition> SettingDefinitions { get; set; }
    }
}