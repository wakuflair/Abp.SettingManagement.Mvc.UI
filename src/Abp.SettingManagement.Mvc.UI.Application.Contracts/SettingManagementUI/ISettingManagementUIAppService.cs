using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.SettingManagement.Mvc.UI.SettingManagementUI.Dto;
using Volo.Abp.Application.Services;

namespace Abp.SettingManagement.Mvc.UI.SettingManagementUI
{
    public interface ISettingManagementUIAppService : IApplicationService
    {
        Task<IEnumerable<SettingGroup>> GroupSettingDefinitions();
        Task SetSettingValues(IDictionary<string, string> settingValues);
    }
}