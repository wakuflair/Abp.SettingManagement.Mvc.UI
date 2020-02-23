For ABP >= 2.1.1, please use [EasyAbp.Abp.SettingUi](https://github.com/EasyAbp/EasyAbp.Abp.SettingUi).

# Abp.SettingManagement.Mvc.UI

An [ABP](http://abp.io) module used to manage ABP settings

![demo](./doc/images/demo.png)

# Features

* Manage ABP setting values via UI
* Support localization
* Control display of the settings via JSON (grouping, form controls, etc.)

# How to use

1. Install nuget packages

    * Application project:
    
        `Install-Package Abp.SettingManagement.Mvc.UI.Application`
    
    * Web project:

        `Install-Package Abp.SettingManagement.Mvc.UI.Web`

1. Add `DependsOn` attributes

    * Application project:

        ``` csharp
        ...
        [DependsOn(typeof(AbpSettingManagementMvcUIApplicationModule))]
        public class YourApplicationModule : AbpModule
        {
            ...
        }
        ```

    * Web project:

        ``` csharp
        ...
        [DependsOn(typeof(AbpSettingManagementMvcUIWebModule))]
        public class YourWebModule : AbpModule
        {
            ...
        }
        ```

1. Configure auto api controller

    * Web project:
  
        ``` csharp
        ...
        public class YourWebModule : AbpModule
        {
            private void ConfigureAutoApiControllers()
            {
                Configure<AbpAspNetCoreMvcOptions>(options =>
                {
                    ...
                    options.ConventionalControllers.Create(typeof(AbpSettingManagementMvcUIApplicationModule).Assembly);
                });
            }
        }

        ```

1. Launch your ABP application, grant the following permissions to your user:

    ![permissions](./doc/images/permissions.png)
  
1. Refresh the browser then you can use "Administration > Settings" menu to see the settings!
            
# Localization

This module uses ABP's localization system to display the localization information of the settings.The languages currently supported are:

* en
* zh-Hans
  
The localization resource files are under `/Localization/AbpSettingManagementMvcUI` of the `Abp.SettingManagement.Mvc.UI.Domain.Shared` project. 

You can add more resource files to make this module support more languages. Welcome PRs :blush: .
> For ABP's localization system, please see [the document](https://docs.abp.io/en/abp/latest/Localization)

# Setting Properties

* Grouping
* Type

TODO

# Setting renderers

* Adding new renderer
* Customizing existed renderers

TODO

# Sample

TODO

OUTLINE:

* MyAbpApp.Domain.Shared

    1. Add setting definitions: `MyAbpAppSettingDefinitionProvider`
    1. Add localization resources: `/Localization/SettingResource`

* MyAbpApp.Web
    
    1. Configure localization option: `MyAbpAppWebModule.ConfigureLocalizationServices`
    1. Configure auto api controller: `MyAbpAppWebModule.ConfigureAutoApiControllers`

# Roadmap

- [ ] Add more languages
- [ ] Support setting providers
