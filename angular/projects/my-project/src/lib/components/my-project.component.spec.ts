import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AbpSettingManagementMvcUIComponent } from './my-project.component';

describe('AbpSettingManagementMvcUIComponent', () => {
  let component: AbpSettingManagementMvcUIComponent;
  let fixture: ComponentFixture<AbpSettingManagementMvcUIComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [AbpSettingManagementMvcUIComponent],
    }).compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AbpSettingManagementMvcUIComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
