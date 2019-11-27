using System;
using System.Threading.Tasks;
using Abp.SettingManagement.Mvc.UI.Authorization;
using Abp.SettingManagement.Mvc.UI.Web.Pages;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NSubstitute;
using Shouldly;
using Volo.Abp.PermissionManagement;
using Volo.Abp.Security.Claims;
using Volo.Abp.SettingManagement.Web.Pages.SettingManagement;
using Volo.Abp.Users;
using Xunit;

namespace Abp.SettingManagement.Mvc.UI.Web.Tests.UI
{
    public class SettingPageContributor_Tests : AbpSettingManagementMvcUIWebTestBase
    {
        private readonly SettingPageContributor _contributor;
        private readonly SettingPageCreationContext _settingPageCreationContext;
        private readonly IPermissionManager _permissionManager;
        private readonly Guid _currentUserId;

        public SettingPageContributor_Tests()
        {
            _contributor = new SettingPageContributor();
            _settingPageCreationContext = new SettingPageCreationContext(ServiceProvider);
            _permissionManager = GetRequiredService<IPermissionManager>();

            // Get current user's Id
            _currentUserId = Guid.Parse(GetRequiredService<ICurrentPrincipalAccessor>().Principal.FindFirst(AbpClaimTypes.UserId).Value);
        }

        [Fact]
        public async Task Should_Has_Permission_For_Global()
        {
            // Arrange
            await _permissionManager.SetForUserAsync(_currentUserId, AbpSettingManagementMvcUIPermissions.Global, true);

            // Act
            bool result = await _contributor.CheckPermissionsAsync(_settingPageCreationContext);

            // Assert
            result.ShouldBeTrue();
        }

        [Fact]
        public async Task Should_Has_Permission_For_Tenant()
        {
            // Arrange
            await _permissionManager.SetForUserAsync(_currentUserId, AbpSettingManagementMvcUIPermissions.Tenant, true);

            // Act
            bool result = await _contributor.CheckPermissionsAsync(_settingPageCreationContext);

            // Assert
            result.ShouldBeTrue();
        }

        [Fact]
        public async Task Should_Has_Permission_For_User()
        {
            // Arrange
            await _permissionManager.SetForUserAsync(_currentUserId, AbpSettingManagementMvcUIPermissions.User, true);

            // Act
            bool result = await _contributor.CheckPermissionsAsync(_settingPageCreationContext);

            // Assert
            result.ShouldBeTrue();
        }

        [Fact]
        public async Task Should_Has_No_Permission()
        {
            // Arrange
            await _permissionManager.SetForUserAsync(_currentUserId, AbpSettingManagementMvcUIPermissions.Global, false);
            await _permissionManager.SetForUserAsync(_currentUserId, AbpSettingManagementMvcUIPermissions.Tenant, false);
            await _permissionManager.SetForUserAsync(_currentUserId, AbpSettingManagementMvcUIPermissions.User, false);

            // Act
            bool result = await _contributor.CheckPermissionsAsync(_settingPageCreationContext);

            // Assert
            result.ShouldBeFalse();

        }
    }
}