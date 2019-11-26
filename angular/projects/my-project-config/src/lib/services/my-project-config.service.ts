import { Injectable } from '@angular/core';
import { eLayoutType, addAbpRoutes, ABP } from '@abp/ng.core';
import { addSettingTab } from '@abp/ng.theme.shared';
import { AbpSettingManagementMvcUISettingsComponent } from '../components/my-project-settings.component';

@Injectable({
  providedIn: 'root',
})
export class AbpSettingManagementMvcUIConfigService {
  constructor() {
    addAbpRoutes({
      name: 'AbpSettingManagementMvcUI',
      path: 'my-project',
      layout: eLayoutType.application,
      order: 2,
    } as ABP.FullRoute);

    const route = addSettingTab({
      component: AbpSettingManagementMvcUISettingsComponent,
      name: 'AbpSettingManagementMvcUI Settings',
      order: 1,
      requiredPolicy: '',
    });
  }
}
