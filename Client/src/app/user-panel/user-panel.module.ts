import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { UserPanelLayoutModule } from './user-panel-layout/user-panel-layout.module';
import { UserPanelLayoutComponentsModule } from './user-panel-layout/user-panel-layout-components/user-panel-layout-components.module';

@NgModule({
  declarations: [],
  imports: [CommonModule, UserPanelLayoutModule, UserPanelLayoutComponentsModule],
  exports: [UserPanelLayoutModule,UserPanelLayoutComponentsModule],
})
export class UserPanelModule {}
