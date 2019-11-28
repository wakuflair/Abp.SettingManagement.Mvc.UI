using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.SettingManagement.Mvc.UI.SettingDefinitionGroup.Dto;
using Volo.Abp.Application.Services;

namespace Abp.SettingManagement.Mvc.UI.SettingDefinitionGroup
{
    public interface ISettingManagementUIAppService : IApplicationService
    {
        Task<IEnumerable<SettingGroup>> GroupSettingDefinitions();
        Task SetSettingValues(IDictionary<string, string> settingValues);
    }
}