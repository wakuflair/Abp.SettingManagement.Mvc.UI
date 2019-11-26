using System.Collections.Generic;
using Volo.Abp.Application.Services;

namespace Abp.SettingManagement.Mvc.UI.SettingDefinitionGroup
{
    public interface ISettingDefinitionGroupAppService : IApplicationService
    {
        IEnumerable<Dto.SettingDefinitionGroup> GroupSettingDefinitions();
    }
}