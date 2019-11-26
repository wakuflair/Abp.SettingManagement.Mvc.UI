using System.Threading.Tasks;
using Abp.SettingManagement.Mvc.UI.Web.Pages;
using Shouldly;
using Volo.Abp.SettingManagement.Web.Pages.SettingManagement;
using Xunit;

namespace Abp.SettingManagement.Mvc.UI.Web.Tests.UI
{
    public class SettingPageContributor_Tests : AbpSettingManagementMvcUIWebTestBase
    {
        private readonly SettingPageContributor _contributor;
        private readonly SettingPageCreationContext _settingPageCreationContext;

        public SettingPageContributor_Tests()
        {
            _contributor = new SettingPageContributor();
            _settingPageCreationContext = new SettingPageCreationContext(ServiceProvider);
        }

        [Fact]
        public async Task Permission_Test()
        {
            // Arrange

            // Act
            bool result = await _contributor.CheckPermissionsAsync(_settingPageCreationContext);

            // Assert
            result.ShouldBeTrue();
        }
    }
}