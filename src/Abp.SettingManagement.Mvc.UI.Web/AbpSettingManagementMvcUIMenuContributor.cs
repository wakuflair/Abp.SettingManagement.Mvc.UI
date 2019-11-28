using System.Threading.Tasks;
using Abp.SettingManagement.Mvc.UI.Authorization;
using Abp.SettingManagement.Mvc.UI.Localization;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Localization;
using Volo.Abp.UI.Navigation;

namespace Abp.SettingManagement.Mvc.UI.Web
{
    public class AbpSettingManagementMvcUIMenuContributor : IMenuContributor
    {
        public async Task ConfigureMenuAsync(MenuConfigurationContext context)
        {
            if (context.Menu.Name == StandardMenus.Main)
            {
                await ConfigureMainMenu(context);
            }
        }

        private async Task ConfigureMainMenu(MenuConfigurationContext context)
        {
            var authorizationService = context.ServiceProvider.GetRequiredService<IAuthorizationService>();
            if (await authorizationService.IsGrantedAsync(AbpSettingManagementMvcUIPermissions.Global) ||
                await authorizationService.IsGrantedAsync(AbpSettingManagementMvcUIPermissions.Tenant) ||
                await authorizationService.IsGrantedAsync(AbpSettingManagementMvcUIPermissions.User))
            {
                var l = context.ServiceProvider.GetRequiredService<IStringLocalizer<AbpSettingManagementMvcUIResource>>();
                context.Menu.GetAdministration()
                    .AddItem(new ApplicationMenuItem(
                            "SettingManagementUI",
                            l["Settings"],
                            "/SettingManagement",
                            icon: "fa fa-cog"
                        )
                    );
            }
        }
    }
}