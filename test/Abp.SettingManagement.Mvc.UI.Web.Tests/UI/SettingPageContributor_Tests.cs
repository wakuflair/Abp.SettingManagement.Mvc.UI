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
        public async Task Should_Has_Permission_For_Admin()
        {
            // Arrange

            // Act
            bool result = await _contributor.CheckPermissionsAsync(_settingPageCreationContext);

            // Assert
            result.ShouldBeTrue();
        }
    }
}