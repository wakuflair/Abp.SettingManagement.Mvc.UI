using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using NSubstitute;
using Shouldly;
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

        [Fact]
        public Task Should_Be_Grouped_Test()
        {
            // Arrange
            // The TestSettingDefinitionsProvider should be executed by module system

            // Act
            var groups = _service.GroupSettingDefinitions();

            // Assert
            var group = groups.Single(g => g.GroupName == "TestGroup1");
            group.GroupDisplayName.ShouldBe("TestGroup1");
            group.SettingDefinitions.Count().ShouldBe(2);

            // The properties of the TestSetting1 are set with "WithProperty" method
            var setting1 = group.SettingDefinitions.Single(sd => sd.Name == "TestSetting1");
            setting1.Properties[AbpSettingManagementMvcUIConst.Group1].ShouldBe("TestGroup1");
            setting1.Properties[AbpSettingManagementMvcUIConst.Group2].ShouldBe("TestGroup2");
            setting1.Properties[AbpSettingManagementMvcUIConst.Type].ShouldBe("number");

            // The properties of the TestSetting2 are set by SettingProperty json file
            var setting2 = group.SettingDefinitions.Single(sd => sd.Name == "TestSetting2");
            setting2.Properties[AbpSettingManagementMvcUIConst.Group1].ShouldBe("TestGroup1");
            setting2.Properties[AbpSettingManagementMvcUIConst.Group2].ShouldBe("TestGroup2");
            setting2.Properties[AbpSettingManagementMvcUIConst.Type].ShouldBe("checkbox");

            return Task.CompletedTask;
        }

        [Fact]
        public Task DefaultProperty_Test()
        {
            // Arrange
            // The TestSettingDefinitionsProvider should be executed by module system

            // Act
            var groups = _service.GroupSettingDefinitions();

            // Assert
            // The property values of the TestSetting3 are default
            var setting3 = groups.SelectMany(grp => grp.SettingDefinitions).Single(sd => sd.Name == "TestSetting3");
            setting3.Properties[AbpSettingManagementMvcUIConst.Group1].ShouldBe(AbpSettingManagementMvcUIConst.DefaultGroup);
            setting3.Properties[AbpSettingManagementMvcUIConst.Group2].ShouldBe(AbpSettingManagementMvcUIConst.DefaultGroup);
            setting3.Properties[AbpSettingManagementMvcUIConst.Type].ShouldBe(AbpSettingManagementMvcUIConst.DefaultType);

            return Task.CompletedTask;
        }
    }
}