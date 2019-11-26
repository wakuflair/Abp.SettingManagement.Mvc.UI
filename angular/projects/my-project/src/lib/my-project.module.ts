import { NgModule } from '@angular/core';
import { AbpSettingManagementMvcUIComponent } from './components/my-project.component';
import { AbpSettingManagementMvcUIRoutingModule } from './my-project-routing.module';
import { ThemeSharedModule } from '@abp/ng.theme.shared';
import { CoreModule } from '@abp/ng.core';

@NgModule({
  declarations: [AbpSettingManagementMvcUIComponent],
  imports: [CoreModule, ThemeSharedModule, AbpSettingManagementMvcUIRoutingModule],
  exports: [AbpSettingManagementMvcUIComponent],
})
export class AbpSettingManagementMvcUIModule {}
