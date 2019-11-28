using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Abp.SettingManagement.Mvc.UI.SettingDefinitionGroup;
using Abp.SettingManagement.Mvc.UI.SettingDefinitionGroup.Dto;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Abp.SettingManagement.Mvc.UI.Web.Pages.AbpSettingManagementMvcUI
{
    public class IndexModel : PageModel
    {
        private readonly ISettingDefinitionGroupAppService _settingDefinitionGroupAppService;
        public IEnumerable<SettingGroup> Groups { get; set; }

        public IndexModel(ISettingDefinitionGroupAppService settingDefinitionGroupAppService)
        {
            _settingDefinitionGroupAppService = settingDefinitionGroupAppService;
        }

        public async Task OnGetAsync()
        {
            Groups = await _settingDefinitionGroupAppService.GroupSettingDefinitions();
        }
    }
}