using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Abp.SettingManagement.Mvc.UI.Authorization;
using Abp.SettingManagement.Mvc.UI.Localization;
using Abp.SettingManagement.Mvc.UI.Web.Views.Components;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Localization;
using Newtonsoft.Json;
using Volo.Abp.Json;
using Volo.Abp.Localization;
using Volo.Abp.SettingManagement.Web.Pages.SettingManagement;
using Volo.Abp.Settings;
using Volo.Abp.VirtualFileSystem;

namespace Abp.SettingManagement.Mvc.UI.Web.Pages
{
    public class SettingPageContributor : ISettingPageContributor
    {
        public Task ConfigureAsync(SettingPageCreationContext context)
        {
            var localizer = context.ServiceProvider.GetService<IStringLocalizer<AbpSettingManagementMvcUIResource>>();
            var virtualFileProvider = context.ServiceProvider.GetService<IVirtualFileProvider>();
            var jsonSerializer = context.ServiceProvider.GetService<IJsonSerializer>();
            var settingDefinitionManager = context.ServiceProvider.GetService<ISettingDefinitionManager>();

            var settingProperties = virtualFileProvider.GetDirectoryContents("/SettingProperties")
                .Select(content =>
                {
                    Debug.WriteLine(content.ReadAsString());
                    return jsonSerializer.Deserialize<IDictionary<string, IDictionary<string, string>>>(
                            content.ReadAsString());
                })
                .SelectMany(dict => dict)
                .ToDictionary(pair => pair.Key, pair => pair.Value);
            var settingDefinitions = settingDefinitionManager.GetAll();
            foreach (var settingDefinition in settingDefinitions)
            {
                if (settingProperties.ContainsKey(settingDefinition.Name))
                {
                    var properties = settingProperties[settingDefinition.Name];
                    foreach (var (k, v) in properties)
                    {
                        settingDefinition.WithProperty(k, v);
                    }
                }
                else
                {
                    settingDefinition
                        .WithProperty(AbpSettingManagementMvcUIConst.Group1, "Others")
                        .WithProperty(AbpSettingManagementMvcUIConst.Group2, "Others");
                }

                if (!settingDefinition.Properties.ContainsKey(AbpSettingManagementMvcUIConst.Type))
                {
                    settingDefinition.WithProperty(AbpSettingManagementMvcUIConst.Type, "text");
                }
            }

            foreach (var grp in settingDefinitions.GroupBy(sd => sd.Properties[AbpSettingManagementMvcUIConst.Group1].ToString()))
            {
                context.Groups.Add(new SettingPageGroup(grp.Key, localizer[grp.Key], typeof(SettingViewComponent), grp.ToList()));
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