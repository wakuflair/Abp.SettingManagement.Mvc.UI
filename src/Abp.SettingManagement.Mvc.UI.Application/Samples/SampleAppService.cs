using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace Abp.SettingManagement.Mvc.UI.Samples
{
    public class SampleAppService : AbpSettingManagementMvcUIAppService, ISampleAppService
    {
        public Task<SampleDto> GetAsync()
        {
            return Task.FromResult(
                new SampleDto
                {
                    Value = 42
                }
            );
        }

        [Authorize]
        public Task<SampleDto> GetAuthorizedAsync()
        {
            return Task.FromResult(
                new SampleDto
                {
                    Value = 42
                }
            );
        }
    }
}