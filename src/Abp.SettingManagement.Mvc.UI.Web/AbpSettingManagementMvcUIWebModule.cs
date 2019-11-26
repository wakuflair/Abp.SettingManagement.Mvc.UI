using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.DependencyInjection;
using Abp.SettingManagement.Mvc.UI.Localization;
using Abp.SettingManagement.Mvc.UI.Web.Pages;
using Volo.Abp.AspNetCore.Mvc.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.Theme.Shared;
using Volo.Abp.AutoMapper;
using Volo.Abp.Modularity;
using Volo.Abp.SettingManagement.Web;
using Volo.Abp.SettingManagement.Web.Pages.SettingManagement;
using Volo.Abp.UI.Navigation;
using Volo.Abp.VirtualFileSystem;

namespace Abp.SettingManagement.Mvc.UI.Web
{
    [DependsOn(
        typeof(AbpSettingManagementMvcUIHttpApiModule),
        typeof(AbpAspNetCoreMvcUiThemeSharedModule),
        typeof(AbpAutoMapperModule)
        )]
    [DependsOn(typeof(AbpSettingManagementWebModule))]
    public class AbpSettingManagementMvcUIWebModule : AbpModule
    {
        public override void PreConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.PreConfigure<AbpMvcDataAnnotationsLocalizationOptions>(options =>
            {
                options.AddAssemblyResource(typeof(AbpSettingManagementMvcUIResource), typeof(AbpSettingManagementMvcUIWebModule).Assembly);
            });

            PreConfigure<IMvcBuilder>(mvcBuilder =>
            {
                mvcBuilder.AddApplicationPartIfNotExists(typeof(AbpSettingManagementMvcUIWebModule).Assembly);
            });
        }

        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpNavigationOptions>(options =>
            {
                options.MenuContributors.Add(new AbpSettingManagementMvcUIMenuContributor());
            });

            Configure<AbpVirtualFileSystemOptions>(options =>
            {
                options.FileSets.AddEmbedded<AbpSettingManagementMvcUIWebModule>("Abp.SettingManagement.Mvc.UI.Web");
            });

            Configure<AbpAutoMapperOptions>(options =>
            {
                options.AddMaps<AbpSettingManagementMvcUIWebModule>(validate: true);
            });

            Configure<RazorPagesOptions>(options =>
            {
                //Configure authorization.
            });

            Configure<SettingManagementPageOptions>(options =>
            {
                options.Contributors.Add(new SettingPageContributor());
            });
        }
    }
}
