using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace Abp.SettingManagement.Mvc.UI.SettingDefinitionGroup
{
    public interface ISettingDefinitionGroupAppService : IApplicationService
    {
        Task<IEnumerable<Dto.SettingDefinitionGroup>> GroupSettingDefinitions();
    }
}