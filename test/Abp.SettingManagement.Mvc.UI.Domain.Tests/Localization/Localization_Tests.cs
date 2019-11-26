using System.Globalization;
using System.IO;
using System.Threading.Tasks;
using Microsoft.Extensions.Localization;
using Shouldly;
using Volo.Abp.Settings;
using Volo.Abp.VirtualFileSystem;
using Xunit;

namespace Abp.SettingManagement.Mvc.UI.Localization
{
    public class Localization_Tests : AbpSettingManagementMvcUIDomainTestBase
    {
        [Fact]
        public Task BuiltIn_Setting_Definitions_Resource_Should_Be_Defined()
        {
            // Arrange
            var settingDefinitions = GetRequiredService<ISettingDefinitionManager>().GetAll();
            var files = GetRequiredService<IVirtualFileProvider>().GetDirectoryContents("/Localization/Settings");
            var localizer = GetRequiredService<IStringLocalizer<AbpSettingManagementMvcUIResource>>();

            // Act

            // Assert
            // Enumerate all the setting localization files: en.json, zh-Hans.json...
            foreach (var content in files)
            {
                // Set the current culture
                string cultureName = Path.GetFileNameWithoutExtension(content.Name);
                CultureInfo.CurrentCulture = CultureInfo.CurrentUICulture = CultureInfo.GetCultureInfo(cultureName);

                // Assert if the localization resource existed.
                foreach (var settingDefinition in settingDefinitions)
                {
                    localizer["DisplayName:" + settingDefinition.Name].ResourceNotFound.ShouldBeFalse($"Resource file: {content.Name} Setting name: {settingDefinition.Name}");
                    localizer["Description:" + settingDefinition.Name].ResourceNotFound.ShouldBeFalse($"Resource file: {content.Name} Setting name: {settingDefinition.Name}");
                }
            }

            return Task.CompletedTask;
        }
    }
}