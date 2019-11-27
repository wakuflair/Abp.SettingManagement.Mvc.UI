using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using NSubstitute;
using Shouldly;
using Volo.Abp.Settings;
using Xunit;
using Xunit.Abstractions;

namespace Abp.SettingManagement.Mvc.UI.SettingDefinitionGroup
{
    public class SettingDefinitionGroupAppService_Tests : AbpSettingManagementMvcUIApplicationTestBase
    {
        private readonly ITestOutputHelper _output;
        private readonly ISettingDefinitionGroupAppService _service;

        public SettingDefinitionGroupAppService_Tests(ITestOutputHelper output)
        {
            _output = output;
            _service = GetRequiredService<ISettingDefinitionGroupAppService>();
        }

        protected override void AfterAddApplication(IServiceCollection services)
        {
            services.AddAlwaysAllowAuthorization();

            // Mock settings
            var settingDefinitionManager = Substitute.For<ISettingDefinitionManager>();
            settingDefinitionManager.GetAll().Returns(new List<SettingDefinition>
            {
                new SettingDefinition("TestSetting1", "1")
                    .WithProperty(AbpSettingManagementMvcUIConst.Group1, "TestGroup1")
                    .WithProperty(AbpSettingManagementMvcUIConst.Group2, "TestGroup2")
                    .WithProperty(AbpSettingManagementMvcUIConst.Type, "number"),
                new SettingDefinition("TestSetting2", "2"),
                new SettingDefinition("TestSetting3", "3")
            });
            services.AddSingleton(settingDefinitionManager);
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

            // The property values of the TestSetting1 are set with "WithProperty" method
            var setting1 = group.SettingDefinitions.Single(sd => sd.Name == "TestSetting1");
            setting1.Properties[AbpSettingManagementMvcUIConst.Group1].ShouldBe("TestGroup1");
            setting1.Properties[AbpSettingManagementMvcUIConst.Group2].ShouldBe("TestGroup2");
            setting1.Properties[AbpSettingManagementMvcUIConst.Type].ShouldBe("number");

            // The property values of the TestSetting2 are from the TestSettingProperties.json file
            var setting2 = group.SettingDefinitions.Single(sd => sd.Name == "TestSetting2");
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
            // The property values of the TestSetting3 are default
            var setting3 = groups.SelectMany(grp => grp.SettingDefinitions).Single(sd => sd.Name == "TestSetting3");
            setting3.Properties[AbpSettingManagementMvcUIConst.Group1].ShouldBe(AbpSettingManagementMvcUIConst.DefaultGroup);
            setting3.Properties[AbpSettingManagementMvcUIConst.Group2].ShouldBe(AbpSettingManagementMvcUIConst.DefaultGroup);
            setting3.Properties[AbpSettingManagementMvcUIConst.Type].ShouldBe(AbpSettingManagementMvcUIConst.DefaultType);
        }
    }
}