using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using NSubstitute;
using Shouldly;
using Volo.Abp.SettingManagement;
using Volo.Abp.Settings;
using Xunit;
using Xunit.Abstractions;

namespace Abp.SettingManagement.Mvc.UI.SettingManagementUI
{
    public class SettingDefinitionGroupAppService_Tests : AbpSettingManagementMvcUIApplicationTestBase
    {
        private readonly ITestOutputHelper _output;
        private readonly ISettingManagementUIAppService _service;
        private ISettingManager _settingManager;

        public SettingDefinitionGroupAppService_Tests(ITestOutputHelper output)
        {
            _output = output;
            _service = GetRequiredService<ISettingManagementUIAppService>();
        }

        protected override void AfterAddApplication(IServiceCollection services)
        {
            services.AddAlwaysAllowAuthorization();

            // Mock ISettingDefinitionManager
            var settingDefinitionManager = Substitute.For<ISettingDefinitionManager>();
            settingDefinitionManager.GetAll().Returns(new List<SettingDefinition>
            {
                new SettingDefinition("Test.Setting1", "1")
                    .WithProperty(AbpSettingManagementMvcUIConst.Group1, "TestGroup1")
                    .WithProperty(AbpSettingManagementMvcUIConst.Group2, "TestGroup2")
                    .WithProperty(AbpSettingManagementMvcUIConst.Type, "number"),
                new SettingDefinition("Test.Setting2", "2"),
                new SettingDefinition("Test.Setting3", "3")
            });
            services.AddSingleton(settingDefinitionManager);

            // Mock ISettingManager
            _settingManager = Substitute.For<ISettingManager>();
            services.AddSingleton(_settingManager);
        }

        [Fact]
        public async Task Settings_Should_Be_Grouped()
        {
            // Arrange
            // The TestSettingDefinitionsProvider should be executed by module system

            // Act
            var groups = await _service.GroupSettingDefinitions();

            // Assert
            var group = groups.Single(g => g.GroupName == "TestGroup1");
            group.GroupDisplayName.ShouldBe("TestGroup1");
            group.SettingDefinitions.Count().ShouldBe(2);

            // The property values of the Test.Setting1 are set with "WithProperty" method
            var setting1 = group.SettingDefinitions.Single(sd => sd.Name == "Test.Setting1");
            setting1.Properties[AbpSettingManagementMvcUIConst.Group1].ShouldBe("TestGroup1");
            setting1.Properties[AbpSettingManagementMvcUIConst.Group2].ShouldBe("TestGroup2");
            setting1.Properties[AbpSettingManagementMvcUIConst.Type].ShouldBe("number");

            // The property values of the Test.Setting2 are from the TestSettingProperties.json file
            var setting2 = group.SettingDefinitions.Single(sd => sd.Name == "Test.Setting2");
            setting2.Properties[AbpSettingManagementMvcUIConst.Group1].ShouldBe("TestGroup1");
            setting2.Properties[AbpSettingManagementMvcUIConst.Group2].ShouldBe("TestGroup2");
            setting2.Properties[AbpSettingManagementMvcUIConst.Type].ShouldBe("checkbox");
        }

        [Fact]
        public async Task Default_Property_Values_Should_Be_Set()
        {
            // Arrange
            // The TestSettingDefinitionsProvider should be executed by module system

            // Act
            var groups = await _service.GroupSettingDefinitions();

            // Assert
            // The property values of the Test.Setting3 are default
            var setting3 = groups.SelectMany(grp => grp.SettingDefinitions).Single(sd => sd.Name == "Test.Setting3");
            setting3.Properties[AbpSettingManagementMvcUIConst.Group1].ShouldBe(AbpSettingManagementMvcUIConst.DefaultGroup);
            setting3.Properties[AbpSettingManagementMvcUIConst.Group2].ShouldBe(AbpSettingManagementMvcUIConst.DefaultGroup);
            setting3.Properties[AbpSettingManagementMvcUIConst.Type].ShouldBe(AbpSettingManagementMvcUIConst.DefaultType);
        }

        [Fact]
        public async Task SettingValues_Should_Be_Set()
        {
            // Arrange
            var settingValues = new Dictionary<string, string>
            {
                {"setting_Test_Setting1", "value1" },
                {"setting_Test_Setting2", "value2" },
                {"RequestToken", "value3" },
            };

            // Act
            await _service.SetSettingValues(settingValues);

            // Assert
            await _settingManager.Received().SetGlobalAsync("Test.Setting1", "value1");
            await _settingManager.Received().SetGlobalAsync("Test.Setting2", "value2");
            await _settingManager.DidNotReceive().SetGlobalAsync("RequestToken", "value3");
        }
    }
}