using System.Globalization;
using System.IO;
using System.Threading.Tasks;
using Abp.SettingManagement.Mvc.UI.Localization;
using Microsoft.Extensions.Localization;
using Shouldly;
using Volo.Abp.Settings;
using Volo.Abp.VirtualFileSystem;
using Xunit;
using Xunit.Abstractions;

namespace Abp.SettingManagement.Mvc.UI.Web.Tests.Localization
{
    public class Localization_Tests : AbpSettingManagementMvcUIWebTestBase
    {
        private readonly ITestOutputHelper _output;

        public Localization_Tests(ITestOutputHelper output)
        {
            _output = output;
        }

        [Fact]
        public Task BuiltIn_Setting_Definitions_Resource_Should_Be_Defined()
        {
            // Arrange
            var settingDefinitions = GetRequiredService<ISettingDefinitionManager>().GetAll();
            var files = GetRequiredService<IVirtualFileProvider>().GetDirectoryContents("/Localization/AbpSettingManagementMvcUI");
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
                    string msg = $"Resource file: {content.Name} Setting name: {settingDefinition.Name}";
                    _output.WriteLine(msg);
                    localizer["DisplayName:" + settingDefinition.Name].ResourceNotFound.ShouldBeFalse(msg);
                    localizer["Description:" + settingDefinition.Name].ResourceNotFound.ShouldBeFalse(msg);
                }
            }

            return Task.CompletedTask;
        }
    }
}