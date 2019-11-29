using Volo.Abp.Settings;

namespace MyAbpApp.Settings
{
    public class MyAbpAppSettingDefinitionProvider : SettingDefinitionProvider
    {
        public override void Define(ISettingDefinitionContext context)
        {
            context.Add(
                new SettingDefinition("MySetting1", "abc")
                    .WithProperty("Group1", "MySettingGroup1")
                    .WithProperty("Group2", "MySettingGroup2"),
                new SettingDefinition("MySetting2", 26.ToString())
            );
        }
    }
}
