using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.SettingManagement.Mvc.UI.SettingDefinitionGroup;
using Abp.SettingManagement.Mvc.UI.SettingDefinitionGroup.Dto;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Abp.SettingManagement.Mvc.UI.Web.Pages.AbpSettingManagementMvcUI
{
    public class IndexModel : PageModel
    {
        private readonly ISettingManagementUIAppService _settingManagementUIAppService;
        public IEnumerable<SettingGroup> Groups { get; set; }

        public IndexModel(ISettingManagementUIAppService settingManagementUIAppService)
        {
            _settingManagementUIAppService = settingManagementUIAppService;
        }

        public async Task OnGetAsync()
        {
            Groups = await _settingManagementUIAppService.GroupSettingDefinitions();
        }

        public async Task OnPostAsync(object obj)
        {
        }
    }
}