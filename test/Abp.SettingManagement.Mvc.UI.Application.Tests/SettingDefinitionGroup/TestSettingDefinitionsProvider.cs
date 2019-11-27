using Volo.Abp.Settings;

namespace Abp.SettingManagement.Mvc.UI.SettingDefinitionGroup
{
    public class TestSettingDefinitionsProvider : SettingDefinitionProvider
    {
        public override void Define(ISettingDefinitionContext context)
        {
            context.Add(new SettingDefinition("TestSetting1", "1")
                .WithProperty(AbpSettingManagementMvcUIConst.Group1, "TestGroup1")
                .WithProperty(AbpSettingManagementMvcUIConst.Group2, "TestGroup2")
                .WithProperty(AbpSettingManagementMvcUIConst.Type, "number")
            );

            context.Add(new SettingDefinition("TestSetting2", "2"));
            context.Add(new SettingDefinition("TestSetting3", "3"));
        }
    }
}