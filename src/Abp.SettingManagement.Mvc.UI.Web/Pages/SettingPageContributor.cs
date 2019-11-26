using System.Threading.Tasks;
using Abp.SettingManagement.Mvc.UI.Authorization;
using Abp.SettingManagement.Mvc.UI.SettingDefinitionGroup;
using Abp.SettingManagement.Mvc.UI.Web.Views.Components;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.SettingManagement.Web.Pages.SettingManagement;

namespace Abp.SettingManagement.Mvc.UI.Web.Pages
{
    public class SettingPageContributor : ISettingPageContributor
    {
        public Task ConfigureAsync(SettingPageCreationContext context)
        {
            var groupService = context.ServiceProvider.GetService<ISettingDefinitionGroupAppService>();

            foreach (var grp in groupService.GroupSettingDefinitions())
            {
                context.Groups.Add(new SettingPageGroup(grp.GroupName, grp.GroupDisplayName, typeof(SettingViewComponent), grp.SettingDefinitions));
            }

            return Task.CompletedTask;
        }

        public async Task<bool> CheckPermissionsAsync(SettingPageCreationContext context)
        {
            var authorizationService = context.ServiceProvider.GetRequiredService<IAuthorizationService>();
            if (await authorizationService.IsGrantedAsync(AbpSettingManagementMvcUIPermissions.Global) ||
                await authorizationService.IsGrantedAsync(AbpSettingManagementMvcUIPermissions.Tenant) ||
                await authorizationService.IsGrantedAsync(AbpSettingManagementMvcUIPermissions.User))
            {
                return true;
            }

            return false;
        }
    }
}