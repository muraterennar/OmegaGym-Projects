import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { UserPanelLayoutComponent } from './user-panel-layout.component';
import { UserPanelLayoutComponentsModule } from './user-panel-layout-components/user-panel-layout-components.module';

@NgModule({
  declarations: [UserPanelLayoutComponent],
  imports: [CommonModule, UserPanelLayoutComponentsModule, RouterModule],
  exports: [UserPanelLayoutComponentsModule],
})
export class UserPanelLayoutModule {}
