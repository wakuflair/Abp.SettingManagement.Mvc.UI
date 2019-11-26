import { AuthGuard, DynamicLayoutComponent, PermissionGuard } from '@abp/ng.core';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AbpSettingManagementMvcUIComponent } from './components/my-project.component';

const routes: Routes = [
  {
    path: '',
    component: DynamicLayoutComponent,
    canActivate: [AuthGuard, PermissionGuard],
    data: { requiredPolicy: '' },
    children: [{ path: '', component: AbpSettingManagementMvcUIComponent }],
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class AbpSettingManagementMvcUIRoutingModule {}
