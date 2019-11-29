using Volo.Abp.Settings;

namespace MyAbpApp.Settings
{
    public class MyAbpAppSettingDefinitionProvider : SettingDefinitionProvider
    {
        public override void Define(ISettingDefinitionContext context)
        {
            context.Add(
                new SettingDefinition("Connection.Ip", "127.0.0.1")
                    .WithProperty("Group1", "Server")
                    .WithProperty("Group2", "Connection"),
                new SettingDefinition("Connection.Port", 8080.ToString() )
            );
        }
    }
}
