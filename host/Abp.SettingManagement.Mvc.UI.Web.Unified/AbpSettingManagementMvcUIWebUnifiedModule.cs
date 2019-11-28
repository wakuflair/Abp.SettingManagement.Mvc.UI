using System;
using System.IO;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Abp.SettingManagement.Mvc.UI.EntityFrameworkCore;
using Abp.SettingManagement.Mvc.UI.MultiTenancy;
using Abp.SettingManagement.Mvc.UI.Web;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Swagger;
using Volo.Abp;
using Volo.Abp.Account.Web;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc.UI.Theme.Basic;
using Volo.Abp.AspNetCore.Mvc.UI.Theme.Shared;
using Volo.Abp.AuditLogging.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.Data;
using Volo.Abp.Emailing;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.SqlServer;
using Volo.Abp.FeatureManagement;
using Volo.Abp.Identity;
using Volo.Abp.Identity.EntityFrameworkCore;
using Volo.Abp.Identity.Web;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Volo.Abp.MultiTenancy;
using Volo.Abp.PermissionManagement;
using Volo.Abp.PermissionManagement.EntityFrameworkCore;
using Volo.Abp.PermissionManagement.Identity;
using Volo.Abp.SettingManagement.EntityFrameworkCore;
using Volo.Abp.TenantManagement;
using Volo.Abp.TenantManagement.EntityFrameworkCore;
using Volo.Abp.TenantManagement.Web;
using Volo.Abp.Threading;
using Volo.Abp.VirtualFileSystem;

namespace Abp.SettingManagement.Mvc.UI
{
    [DependsOn(
        typeof(AbpSettingManagementMvcUIWebModule),
        typeof(AbpSettingManagementMvcUIApplicationModule),
        typeof(AbpSettingManagementMvcUIEntityFrameworkCoreModule),
        typeof(AbpAuditLoggingEntityFrameworkCoreModule),
        typeof(AbpAutofacModule),
        typeof(AbpAccountWebModule),
        typeof(AbpEntityFrameworkCoreSqlServerModule),
        typeof(AbpSettingManagementEntityFrameworkCoreModule),
        typeof(AbpPermissionManagementEntityFrameworkCoreModule),
        typeof(AbpPermissionManagementApplicationModule),
        typeof(AbpIdentityWebModule),
        typeof(AbpIdentityApplicationModule),
        typeof(AbpIdentityEntityFrameworkCoreModule),
        typeof(AbpPermissionManagementDomainIdentityModule),
        typeof(AbpFeatureManagementApplicationModule),
        typeof(AbpTenantManagementWebModule),
        typeof(AbpTenantManagementApplicationModule),
        typeof(AbpTenantManagementEntityFrameworkCoreModule),
        typeof(AbpAspNetCoreMvcUiBasicThemeModule)
        )]
    // The email module seems not included in the startup template, so we add it manually
    [DependsOn(typeof(AbpEmailingModule))]
    public class AbpSettingManagementMvcUIWebUnifiedModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            var hostingEnvironment = context.Services.GetHostingEnvironment();
            var configuration = context.Services.GetConfiguration();

            Configure<AbpDbContextOptions>(options =>
            {
                options.UseSqlServer();
            });

            if (hostingEnvironment.IsDevelopment())
            {
                Configure<AbpVirtualFileSystemOptions>(options =>
                {
                    options.FileSets.ReplaceEmbeddedByPhysical<AbpSettingManagementMvcUIDomainSharedModule>(Path.Combine(hostingEnvironment.ContentRootPath, string.Format("..{0}..{0}src{0}Abp.SettingManagement.Mvc.UI.Domain.Shared", Path.DirectorySeparatorChar)));
                    options.FileSets.ReplaceEmbeddedByPhysical<AbpSettingManagementMvcUIDomainModule>(Path.Combine(hostingEnvironment.ContentRootPath, string.Format("..{0}..{0}src{0}Abp.SettingManagement.Mvc.UI.Domain", Path.DirectorySeparatorChar)));
                    options.FileSets.ReplaceEmbeddedByPhysical<AbpSettingManagementMvcUIApplicationContractsModule>(Path.Combine(hostingEnvironment.ContentRootPath, string.Format("..{0}..{0}src{0}Abp.SettingManagement.Mvc.UI.Application.Contracts", Path.DirectorySeparatorChar)));
                    options.FileSets.ReplaceEmbeddedByPhysical<AbpSettingManagementMvcUIApplicationModule>(Path.Combine(hostingEnvironment.ContentRootPath, string.Format("..{0}..{0}src{0}Abp.SettingManagement.Mvc.UI.Application", Path.DirectorySeparatorChar)));
                    options.FileSets.ReplaceEmbeddedByPhysical<AbpSettingManagementMvcUIWebModule>(Path.Combine(hostingEnvironment.ContentRootPath, string.Format("..{0}..{0}src{0}Abp.SettingManagement.Mvc.UI.Web", Path.DirectorySeparatorChar)));
                });
            }

            context.Services.AddSwaggerGen(
                options =>
                {
                    options.SwaggerDoc("v1", new OpenApiInfo { Title = "AbpSettingManagementMvcUI API", Version = "v1" });
                    options.DocInclusionPredicate((docName, description) => true);
                    options.CustomSchemaIds(type => type.FullName);
                });

            Configure<AbpLocalizationOptions>(options =>
            {
                options.Languages.Add(new LanguageInfo("cs", "cs", "??e??tina"));
                options.Languages.Add(new LanguageInfo("en", "en", "English"));
                options.Languages.Add(new LanguageInfo("pt-BR", "pt-BR", "Portugu??s (Brasil)"));
                options.Languages.Add(new LanguageInfo("tr", "tr", "T??rk??e"));
                options.Languages.Add(new LanguageInfo("zh-Hans", "zh-Hans", "Chinese"));
            });

            Configure<AbpMultiTenancyOptions>(options =>
            {
                options.IsEnabled = MultiTenancyConsts.IsEnabled;
            });

            // Auto controllers
            Configure<AbpAspNetCoreMvcOptions>(options =>
            {
                options.ConventionalControllers.Create(typeof(AbpSettingManagementMvcUIApplicationModule).Assembly);
            });
        }

        public override void OnApplicationInitialization(ApplicationInitializationContext context)
        {
            var app = context.GetApplicationBuilder();

            if (context.GetEnvironment().IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseErrorPage();
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseVirtualFiles();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            if (MultiTenancyConsts.IsEnabled)
            {
                app.UseMultiTenancy();
            }

            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "Support APP API");
            });

            app.UseAbpRequestLocalization();
            app.UseAuditing();
            app.UseMvcWithDefaultRouteAndArea();

            using (var scope = context.ServiceProvider.CreateScope())
            {
                AsyncHelper.RunSync(async () =>
                {
                    await scope.ServiceProvider
                        .GetRequiredService<IDataSeeder>()
                        .SeedAsync();
                });
            }
        }
    }
}
