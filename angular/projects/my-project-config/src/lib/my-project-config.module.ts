import { NgModule, APP_INITIALIZER } from '@angular/core';
import { AbpSettingManagementMvcUIConfigService } from './services/my-project-config.service';
import { noop } from '@abp/ng.core';
import { AbpSettingManagementMvcUISettingsComponent } from './components/my-project-settings.component';

@NgModule({
  declarations: [AbpSettingManagementMvcUISettingsComponent],
  providers: [{ provide: APP_INITIALIZER, deps: [AbpSettingManagementMvcUIConfigService], multi: true, useFactory: noop }],
  exports: [AbpSettingManagementMvcUISettingsComponent],
  entryComponents: [AbpSettingManagementMvcUISettingsComponent],
})
export class AbpSettingManagementMvcUIConfigModule {}
